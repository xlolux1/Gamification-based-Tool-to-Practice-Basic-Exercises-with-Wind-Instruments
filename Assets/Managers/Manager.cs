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
    private GUI graphicalInterface = new GUI();
    private readonly static Manager singleton = new Manager();





    private ProfiDao daoProfi = new ProfiDao();
    private PlayerDao daoPlayer = new PlayerDao();
    private Player currentPlayer;

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
        parser.LoadJson5();
        for (int i = 0; i < exercise.list_notes.Count; ++i) {
            var midi  = exercise.list_notes[i].midi;
            Durations duration = exercise.list_notes[i].duration;

            graphicalInterface.drawNote(midi,duration,noteImage,quaver,i);
        }
        //graphicalInter
        //graphicalInterface.drawScala(scale,noteImage);
    }








    public bool Login(string username,string password){
        bool response = true;
        MySqlConnection sqlConnection = ManagerConnection.getConnection();
        Player loggedPlayer = this.daoPlayer.getPlayer_User_Password(sqlConnection,username,password);
        if(loggedPlayer == null){
            response =false;
        }else{
            this.currentPlayer = loggedPlayer;
        }
        ManagerConnection.closeConnection(sqlConnection);
        return response;

    }

    public string Register(string username,string password,string name,string surname,string email){
        string response = "OK";
        MySqlConnection sqlConnection = ManagerConnection.getConnection();
        //Player loggedPlayer = this.daoPlayer.getPlayer_User_Password(sqlConnection,username,password);
            Player newPlayer = new Player(username,name,surname,email,password);
            try{
                this.daoPlayer.insertPlayer(sqlConnection,newPlayer);
            }catch(MySql.Data.MySqlClient.MySqlException e){
                UnityEngine.Debug.Log("[PLAYER DAO EXCEPTION]"+ e.ToString());
                response = "Username already exists";
                sqlConnection.Close();
            }finally{
                UnityEngine.Debug.Log("[PLAYER DAO EXCEPTION]"+ "Something went wrong creating user");
                response = "Something went wrong creating user";
                sqlConnection.Close();
            }
            //response = "This username is already in use";
            ManagerConnection.closeConnection(sqlConnection);
        return response;
    }

    public string createProfile(string username,string instrument, string tune){
        MySqlConnection sqlConection = ManagerConnection.getConnection();
        string response = "OK";
        try{
            this.daoProfi.insertProfile(sqlConection,this.currentPlayer,instrument,tune);
        }catch(Exception e){
            UnityEngine.Debug.Log("[CREATE PROFILE EXCEPTION]"+ e.ToString());
            sqlConection.Close();
            response ="Error";
        }
        return response;
    }

    public string createScale(string tune,string signature,int beats,string scaleType,string firstNote,string duration){
        MySqlConnection sqlConection = ManagerConnection.getConnection();
        string response = "OK";
        try{
            this.daoProfi.insertProfile(sqlConection,this.currentPlayer,instrument,tune);
        }catch(Exception e){
            UnityEngine.Debug.Log("[CREATE PROFILE EXCEPTION]"+ e.ToString());
            sqlConection.Close();
            response ="Error";
        }
        return response;
    }
    
}