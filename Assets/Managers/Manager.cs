using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using PitchDetector;
using SimpleJSON;
using MySql.Data.MySqlClient;
using daos;
public sealed class Manager{

    private JsonParser parser = new JsonParser();
    private GuiManager graphicalInterface = new GuiManager();
    private readonly static Manager singleton = new Manager();
    private ManagerConnection manConnection = 
    new ManagerConnection( "server=sql7.freemysqlhosting.net;database=sql7340480;uid=sql7340480;pwd=kp5Jv9EDj2;port=3306;Convert Zero Datetime=True");
    private ProfiDao daoProfi = new ProfiDao();
    private PlayerDao daoPlayer = new PlayerDao();
    private RoutinesDao daoRoutines = new RoutinesDao();
    private RoutineExerciseDao daoRoutineExercise = new RoutineExerciseDao();
    private ProfileRoutinesDao daoProfileRoutines = new ProfileRoutinesDao();
    private ExerciseDao daoExercise = new ExerciseDao();
    private ScaleDao daoScale = new ScaleDao();
    private Player currentPlayer;
    private Profile currentProfile;

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
            this.manConnection.closeConnection();
            UnityEngine.Debug.Log("[EXCEPTION CATCHED]" + e.Message);
        }
       return exercise;
    }

    public void drawExercise(Exercise ejercicio){
        graphicalInterface.drawMusicStaff();
    }

    public void drawScala(Exercise exercise,GameObject noteImage,GameObject quaver){
        parser.LoadJson5();
        for (int i = 0; i < exercise.list_notes.Count; ++i) {
            var midi  = exercise.list_notes[i].midi;
            Durations duration = exercise.list_notes[i].duration;

            graphicalInterface.drawNote(midi,duration,noteImage,quaver,i);
        }
        //graphicalInter
        //graphicalInterface.drawScala(scale,noteImage);
    }








    public string Login(string username,string password){
        string response = "OK";
        MySqlConnection sqlConnection = manConnection.getConnection();
        Player loggedPlayer = null;
        try{
            loggedPlayer = this.daoPlayer.getPlayer_User_Password(sqlConnection,username,password);

        }catch(Exception e ){
            this.manConnection.closeConnection();
            UnityEngine.Debug.Log("[LOGIN] Exception"+e.Message);
            response = "Error Logging";
        }
        if(loggedPlayer == null){
            response ="User not registered";
        }else{
            this.currentPlayer = loggedPlayer;
        }
        return response;

    }

    private string createCreativeRoutine(Player player,Profile profile,MySqlConnection sqlConnection){
        string response = "OK";
        UnityEngine.Debug.Log("[Create Creative Routine]");
        int count = -1;
        count = this.daoRoutines.getLastNumberRoutine(sqlConnection);
        sqlConnection = manConnection.getConnection();
        RoutinesEx routine = null;
        if(count>-1){
            try{
                routine = new RoutinesEx(count+1,"Creative Mode","2008-7-04",1);
                this.daoRoutines.insertRoutine(sqlConnection,routine);
            }catch(Exception e){
                this.manConnection.closeConnection();
                response = "Error inserting Routine";
                UnityEngine.Debug.Log("[createCreativeRoutine EXCEPTION] insertRoutine"+e.Message);
            }
            try{
                this.daoProfileRoutines.insertProfileRoutine(routine,profile,sqlConnection);
            }catch(Exception e){
                this.manConnection.closeConnection();
                response = "Error inserting Routine in a profile";
                UnityEngine.Debug.Log("[createCreativeRoutine EXCEPTION] insertRoutine"+e.Message);                        
            }
        }
        return response;
    }

    public string Register(string username,string password,string name,string surname,string email){
        string response = "OK";
        MySqlConnection sqlConnection = manConnection.getConnection();
            Player newPlayer = new Player(username,name,surname,email,password);
            try{
                this.daoPlayer.insertPlayer(sqlConnection,newPlayer);
            }catch(MySql.Data.MySqlClient.MySqlException e){
                this.manConnection.closeConnection();
                UnityEngine.Debug.Log("[PLAYER DAO EXCEPTION]"+ e.ToString());
                response = "Username already exists";
            }catch(Exception e){
                this.manConnection.closeConnection();
                UnityEngine.Debug.Log("[PLAYER DAO EXCEPTION]"+ "Something went wrong creating user");
                response = "Something went wrong creating user";
            }
            //response = "This username is already in use";
        return response;
    }

    public string createProfile(string instrument){
        MySqlConnection sqlConection = manConnection.getConnection();
        Profile insertedProfile = null;
        string response = "OK";
        try{
            this.daoProfi.insertProfile(sqlConection,this.currentPlayer,instrument);
             insertedProfile = new Profile(this.currentPlayer.username,instrument);
            
        }catch(Exception e){
            this.manConnection.closeConnection();
            UnityEngine.Debug.Log("[CREATE PROFILE EXCEPTION]"+ e.ToString());
            response ="Error";
        }
        sqlConection = manConnection.getConnection();
        this.createCreativeRoutine(this.currentPlayer,insertedProfile,sqlConection);
        return response;
    }

    public string createScale(string tune,string timeSignature,int beats,string scaleType,string firstNote,int duration,
    string username,string instrument,int idRoutine){
        UnityEngine.Debug.Log("Scale type"+ scaleType);
        ScaleExercise ex = new ScaleExercise(tune,beats,timeSignature,firstNote,scaleType,duration);
        MySqlConnection sqlConection = manConnection.getConnection();
        if(username == this.currentPlayer.username && instrument ==this.currentProfile.instrument){
            int count = -1;
            try{
                 count = this.daoScale.getCountExercises(sqlConection);
            }catch(Exception e){
                this.manConnection.closeConnection();
                UnityEngine.Debug.Log("[Exception] Create scale:"+e.Message);
            }  
                ex.idExercise = count + 1;
                this.inserScale(ex);
                this.createRoutineExercise(idRoutine,ex);
        }
        return null;
    }


    private string createRoutineExercise(int idRoutine,Exercise exercise){
        MySqlConnection sqlConection =manConnection.getConnection();
        try{
            this.daoRoutineExercise.insertRoutineExercise(sqlConection,idRoutine,exercise);
        }catch(Exception e){
            this.manConnection.closeConnection();
            UnityEngine.Debug.Log("[Exception] Create Routine Exercise:"+e.Message);

        }
        return null;
    }

    private string inserScale(ScaleExercise scale){
        MySqlConnection sqlConection = manConnection.getConnection();
        try{
            this.daoScale.insertScale(sqlConection,scale);
        }catch(Exception e){
            this.manConnection.closeConnection();

        }
        return null;
    }

    public List<string> getInstrumentsPlayer(){
        List<string> listInstruments = new List<string>();
        MySqlConnection sqlConection = manConnection.getConnection();
        try{
            
          listInstruments =  this.daoProfi.getInstruments(sqlConection,this.currentPlayer);
        }catch(Exception e){
            this.manConnection.closeConnection();
           UnityEngine.Debug.Log("[Get INSTRUMENTS EXCEPTION]"+ e.ToString());
        }
        return listInstruments;
    }

    public bool selectProfile(string instrument){
        bool selectProfile= false;
        MySqlConnection sqlConection = manConnection.getConnection();
        try{
            int count = this.daoProfi.selectProfile(sqlConection,this.currentPlayer,instrument);
            if(count == 1){
                this.currentProfile = new Profile(this.currentPlayer.username,instrument);
                selectProfile = true;
            }        
        }catch(Exception e){
            this.manConnection.closeConnection();
            UnityEngine.Debug.Log("[selectProfile EXCEPTION]"+ e.ToString());
        }
        return selectProfile;
    }

    public List<Tuple<int, string>> getExerciesFromRoutine(string username,string profile,int routineId){
        List<Tuple<int, string>> listExercises = new  List<Tuple<int, string>>();
        MySqlConnection sqlConection = manConnection.getConnection();
        //try{
        RoutinesEx routine =this.daoRoutines.selectRoutineFromID(sqlConection,routineId);
          listExercises =  this.daoRoutineExercise.getExerciesDescriptionFromRoutine(sqlConection,routine);
       /* }catch(Exception e){
           UnityEngine.Debug.Log("[Get INSTRUMENTS EXCEPTION]"+ e.ToString());
            sqlConection.Close();
        }*/
        return listExercises;
    }

    public int getCreativeRoutine(string username,string instrument){
        int idCreativeRoutine = -1;
        MySqlConnection sqlConection = manConnection.getConnection();
        try{
            Profile workingProfile = new Profile(username,instrument);
          idCreativeRoutine = this.daoProfileRoutines.getCreativeRoutine(workingProfile,sqlConection);
        }catch(Exception e){
            this.manConnection.closeConnection();
           UnityEngine.Debug.Log("[Get Creative Routine EXCEPTION]"+ e.ToString());
        }
        return idCreativeRoutine;
    }

    public string GetExercise(int idExercise){
        MySqlConnection sqlConection = manConnection.getConnection();
        string response="OK";
        Exercise ex = null;
        try{

             ex = this.daoExercise.getExerciseFromId(sqlConection,idExercise);
        }catch(Exception e){
            this.manConnection.closeConnection();
            UnityEngine.Debug.Log("[set current Exercise form ID EXCEPTION]"+ e.ToString());
        }
        return response;

    }

    
    public string getTypeOfExercise(int idExercise){
        MySqlConnection sqlConection = manConnection.getConnection();
        bool isScale =false;
        string type="";
            try{
              isScale = this.daoScale.isScale(sqlConection,idExercise);

            }catch(Exception e){
                this.manConnection.closeConnection();
            UnityEngine.Debug.Log("[set current Exercise form ID EXCEPTION]"+ e.ToString());
        }
        if(isScale){
            type="Scale";
        }
        return type;    
    }

    public string readRoutine(){
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
        return null;
    }
        public List<Tuple<int, string>> getRoutinesPlayer(string username,string profile){
        List<Tuple<int, string>> listRoutines = new  List<Tuple<int, string>>();
        List<RoutinesEx> listRoutine =new List<RoutinesEx>();
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
        return listRoutines;
    }
    
}