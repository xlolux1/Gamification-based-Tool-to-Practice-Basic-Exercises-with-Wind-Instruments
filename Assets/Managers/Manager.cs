using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using PitchDetector;
using SimpleJSON;
using MySql.Data.MySqlClient;
using daos;
using UnityEngine.Networking;
namespace Managers{
public sealed class Manager{

    private JsonParser parser = new JsonParser();
    private GuiManager graphicalInterface = new GuiManager();
    private readonly static Manager singleton = new Manager();
    private ProfiDao daoProfi = new ProfiDao();
    private PlayerDao daoPlayer = new PlayerDao();
    private RoutinesDao daoRoutines = new RoutinesDao();
    private RoutineExerciseDao daoRoutineExercise = new RoutineExerciseDao();
    private ProfileRoutinesDao daoProfileRoutines = new ProfileRoutinesDao();
    private ExerciseDao daoExercise = new ExerciseDao();
    private ScaleDao daoScale = new ScaleDao();
    public Player currentPlayer;
    public Profile currentProfile;
    public Exercise currentExercise;


    private Manager(){
    }
 
    public static Manager Instance{
        get{
            return singleton;
        }
    }

    public  Exercise startExercise(){
        Exercise exercise = null;
        try{
         exercise =parser.LoadJson5();
        exercise.getStringNotes();

        }catch(DurationException e){
            UnityEngine.Debug.Log("[EXCEPTION CATCHED]" + e.Message);
        }
       return exercise;
    }

    public void drawExercise(Exercise ejercicio){
        graphicalInterface.drawMusicStaff();
    }

    public void drawScala(Exercise exercise,GameObject noteImage,GameObject quaver){
        
        //parser.LoadJson5();
        for (int i = 0; i < exercise.list_notes.Count; ++i) {
            var midi  = exercise.list_notes[i].midi;
            Durations duration = exercise.list_notes[i].duration;

            graphicalInterface.drawNote(midi,duration,noteImage,quaver,i);
        }
        //graphicalInter
        //graphicalInterface.drawScala(scale,noteImage);
    }

    public void changeColour(Durations dur,double percentage,int position){
        string colour="red";
        if(percentage >= 0.0 && percentage <0.4){
            colour = "red";
        }else if(percentage >= 0.4 && percentage <=0.7){
            colour = "yellow";
        }else{
            colour = "green";
        }


        Sprite sprit = graphicalInterface.getInitialSprite(dur,colour);
        graphicalInterface.listGameObjects[position].GetComponent<SpriteRenderer>().sprite = sprit;
    }








    public string Login(string username,string password){
        string response = "error";
        Player loggedPlayer = null;
        try{
            loggedPlayer = this.daoPlayer.getPlayer_User_PasswordM(username,password);

        }catch(Exception e ){
            UnityEngine.Debug.Log("[LOGIN] Exception"+e.Message);
            response = "Wrong credentials";
        }
        if(loggedPlayer == null){
           response ="User not registered";
        }else{
            response = "User logged";
            this.currentPlayer = loggedPlayer;
        }
        return response;
    }

    private string createCreativeRoutine(Player player,Profile profile){
        string response = "OK";
        UnityEngine.Debug.Log("[Create Creative Routine]");
        int count = -1;
        count = this.daoRoutines.getLastNumberRoutineM();
        RoutinesEx routine = null;
        if(count>-1){
            try{
                routine = new RoutinesEx(count+1,"Creative Mode","2008-7-04",1);
                this.daoRoutines.insertRoutineM(routine);
            }catch(Exception e){
                response = "Error inserting Routine";
                UnityEngine.Debug.Log("[createCreativeRoutine EXCEPTION] insertRoutine"+e.Message);
            }
            try{
                this.daoProfileRoutines.insertProfileRoutineM(routine,profile);
            }catch(Exception e){
                response = "Error inserting Routine in a profile";
                UnityEngine.Debug.Log("[createCreativeRoutine EXCEPTION] insertRoutine"+e.Message);                        
            }
        }
        return response;
    }

    public string Register(string username,string password,string name,string surname,string email){
        string response = "";
            Player newPlayer = new Player(username,name,surname,email,password);
            try{
                response = this.daoPlayer.insertPlayerM(newPlayer);
            }catch(Exception e){
                UnityEngine.Debug.Log("[PLAYER DAO EXCEPTION]"+e.Message);
                response = "Something went wrong creating user";
            }
        return response;
    }

    public string createProfile(string username,string instrument){
        Profile insertedProfile = null;
        string response = "OK";
        try{
            response = this.daoProfi.insertProfileM(username,instrument);
             insertedProfile = new Profile(username,instrument);
            
        }catch(Exception e){
            UnityEngine.Debug.Log("[CREATE PROFILE EXCEPTION]"+ e.ToString());
            response ="Error";
        };
        this.createCreativeRoutine(this.currentPlayer,insertedProfile);
        return response;
    }

    public string createScale(string tune,string timeSignature,int beats,string scaleType,string firstNote,int duration,
    string username,string instrument,int idRoutine){
        UnityEngine.Debug.Log("Scale type"+ scaleType);
        ScaleExercise ex = new ScaleExercise(tune,beats,timeSignature,firstNote,scaleType,duration);
        if(username == this.currentPlayer.username && instrument ==this.currentProfile.instrument){
            int count = -1;
            try{
                 count = this.daoScale.getCountExercisesM();
            }catch(Exception e){
                UnityEngine.Debug.Log("[Exception] Create scale:"+e.Message);
            }  
                ex.idExercise = count + 1;
                this.inserScale(ex);
                this.createRoutineExercise(idRoutine,ex);
        }
        return null;
    }


    private string createRoutineExercise(int idRoutine,Exercise exercise){
        string response =" no response";
        try{
            response = this.daoRoutineExercise.insertRoutineExerciseM(idRoutine,exercise);
        }catch(Exception e){
            response = "error";
            UnityEngine.Debug.Log("[Exception] Create Routine Exercise:"+e.Message);
        }
        return response;
    }

    private string inserScale(ScaleExercise scale){
        string response ="";

        try{
           response = this.daoScale.insertScaleM(scale);
        }catch(Exception e){
            UnityEngine.Debug.Log("[Manager][InsertScale]:"+e.Message);

        }
        return response;
    }

    public List<string> getInstrumentsPlayer(){
        List<string> listInstruments = new List<string>();
        try{
            
          listInstruments =  this.daoProfi.getInstrumentsM(this.currentPlayer);
        }catch(Exception e){
           UnityEngine.Debug.Log("[Get INSTRUMENTS EXCEPTION]"+ e.ToString());
        }
        return listInstruments;
    }

    public bool selectProfile(string instrument){
        bool selectProfile= false;
        try{
            int count = this.daoProfi.selectProfileM(this.currentPlayer.username,instrument);
            if(count == 1){
                this.currentProfile = new Profile(this.currentPlayer.username,instrument);
                selectProfile = true;
            }        
        }catch(Exception e){
            UnityEngine.Debug.Log("[selectProfile EXCEPTION]"+ e.ToString());
        }
        return selectProfile;
    }

    public List<Tuple<int, string>> getExerciesFromRoutine(string username,string profile,int routineId){
        List<Tuple<int, string>> listExercises = new  List<Tuple<int, string>>();
        try{
        RoutinesEx routine =this.daoRoutines.selectRoutineFromIDM(routineId);
          listExercises =  this.daoRoutineExercise.getExerciesDescriptionFromRoutineM(routine);
        }catch(Exception e){
           UnityEngine.Debug.Log("[Get INSTRUMENTS EXCEPTION]"+ e.ToString());
        }
        return listExercises;
    }

    public int getCreativeRoutine(string username,string instrument){
        int idCreativeRoutine = -1;
        try{
            Profile workingProfile = new Profile(username,instrument);
          idCreativeRoutine = this.daoProfileRoutines.getCreativeRoutineM(workingProfile);
        }catch(Exception e){
           UnityEngine.Debug.Log("[Get Creative Routine EXCEPTION]"+ e.ToString());
        }
        return idCreativeRoutine;
    }

    public string setCurrentExercise(int idExercise){
        /*
         MySqlConnection sqlConection = manConnection.getConnection();
        string response="OK";
        Exercise ex = null;
        ScaleExercise scale = null;
        try{

             ex = this.daoExercise.getExerciseFromId(sqlConection,idExercise);
        }catch(Exception e){
            this.manConnection.closeConnection();
            UnityEngine.Debug.Log("[set current Exercise form ID EXCEPTION]"+ e.ToString());
        }
        try{
            if(this.daoScale.isScale(sqlConection,idExercise)){
                ex = this.daoScale.getScale(sqlConection,idExercise,ex);

            }

        }catch(Exception e){

        }
        this.currentExercise = ex;
        */
        return null;
       
    }

    public string GetExercise(int idExercise){
        string response="OK";
        Exercise ex = null;
        try{

             ex = this.daoExercise.getExerciseFromIdM(idExercise);
        }catch(Exception e){
            UnityEngine.Debug.Log("[set current Exercise form ID EXCEPTION]"+ e.ToString());
        }
        this.currentExercise = ex;
        return response;
    }

    
    public string getTypeOfExercise(int idExercise){
        bool isScale =false;
        string type="";
            try{
              isScale = this.daoScale.isScaleM(idExercise);

            }catch(Exception e){
            UnityEngine.Debug.Log("[GetTypeOfExercise Exception]"+ e.ToString());
            type = "Error getting type";
        }
        if(isScale){
            type="Scale";
        }
        return type;    
    }

    public string readRoutine(){
        /*
       RoutinesEx routine = parser.readRoutine();
       MySqlConnection sqlConection = manConnection.getConnection();

       try{
           int lastRoutine = this.daoRoutines.getLastNumberRoutine(sqlConection);
           routine.id = lastRoutine+1;
           this.daoRoutines.insertRoutine(sqlConection,routine);
           this.daoProfileRoutines.insertProfileRoutine(routine,this.currentProfile,sqlConection);
       }catch(Exception e){
                 this.manConnection.closeConnection();
                UnityEngine.Debug.Log("[Insert Routine]"+ e.ToString());            
       }
       for(int i=0;i<routine.listScales.Count;i++){
           UnityEngine.Debug.Log("EEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            try{
                int count =this.daoScale.getCountExercises(sqlConection);
                routine.listScales[i].idExercise = count + 1;
                this.daoScale.insertScale(sqlConection,routine.listScales[i]);
                this.daoRoutineExercise.insertRoutineExercise(sqlConection,routine.id,routine.listScales[i]);
            }catch(Exception e){
                this.manConnection.closeConnection();
                UnityEngine.Debug.Log("[Read routine]"+ e.ToString());           
            }
       }
       */
        return null;
    }
        public List<Tuple<int, string>> getRoutinesPlayer(string username,string profile){
           
        List<Tuple<int, string>> listRoutines = new  List<Tuple<int, string>>();
        /* List<RoutinesEx> listRoutine =new List<RoutinesEx>();
        MySqlConnection sqlConection = manConnection.getConnection();
        List<int> listIdRoutines = new List<int>();
        //try{
        listIdRoutines = this.daoProfileRoutines.getRoutinesIdProfileNoCreative(this.currentProfile,sqlConection);

        for(int i=0; i<listIdRoutines.Count;i++){
            RoutinesEx routine = this.daoRoutines.selectRoutineFromID(sqlConection,listIdRoutines[i]);
            listRoutine.Add(routine);
        }
        for(int j=0;j<listRoutine.Count;j++){
            Tuple<int, string> routin = new Tuple <int, string>(listRoutine[j].id,listRoutine[j].description);
            listRoutines.Add(routin);


        }
        */
        return listRoutines;
    }

    public int getNumberRoutinesProfile(string username, string instrument){
        Profile profi = new Profile(username,instrument);
        int number = -1;
        try{
            number = this.daoProfileRoutines.getNumberRoutinesFromProfileM(profi);

        }catch(Exception e){
            UnityEngine.Debug.Log("[Manager][getNumberRoutinesProfile]"+e.Message);
            number = -1;
        }
        return number;
        
    }
    public int getNumberExercises(string username,string instrument){
        /*
        MySqlConnection sqlConection = manConnection.getConnection();
        Profile profi = new Profile(username,instrument);
        List<int> listRoutinesIds = new List<int>();
        int count = 0;
        try{
           listRoutinesIds = this.daoProfileRoutines.getRoutinesIdProfile(profi,sqlConection);

        }catch(Exception e){
            this.manConnection.closeConnection();
            UnityEngine.Debug.Log("[Manager][getNumberExercises]"+e.Message);
        }
        try{
            for(int i = 0;i<listRoutinesIds.Count;i++){
                count = this.daoRoutineExercise.getNumberExercisesFromIdRoutine(sqlConection,listRoutinesIds[i])+ count;
            }
        }catch(Exception e){
            UnityEngine.Debug.Log("[Manager][getNumberExercisesFromIdRoutine]"+e.Message);
        this.manConnection.closeConnection();
        }
        return count;
        */
        return 1;
    }
}
}