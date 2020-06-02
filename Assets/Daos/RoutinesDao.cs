
using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
public class RoutinesDao{



    public string insertRoutine(MySqlConnection connection,RoutinesEx routine){
        MySqlCommand cmd = connection.CreateCommand();
                UnityEngine.Debug.Log("INSERT INTO Routines(idRoutine,description,finalDate) Values("+routine.id+",'"+
        routine.description+"','"+routine.date+"','"+routine.creative+")");
        cmd.CommandText= "INSERT INTO Routines(idRoutine,description,finalDate) Values("+routine.id+",'"+
        routine.description+"','"+routine.date+"');";

        MySqlDataReader reader = cmd.ExecuteReader();
        reader.Close();
        return null;
    } 
    public int getLastNumberRoutine(MySqlConnection connection){
        int count = -1;
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT count(*) FROM Routines;";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
             count = reader.GetInt32(0);
        }
        reader.Close();
        return count;
    }

    public RoutinesEx selectRoutineFromID(MySqlConnection connection,int idRoutine){
        UnityEngine.Debug.Log("[SelectRoutineFromID]"+ idRoutine);
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "Select * From Routines Where idRoutine="+idRoutine+";";
        MySqlDataReader reader = cmd.ExecuteReader();
        RoutinesEx routine = null;
        while (reader.Read()){
            int _id_routine = reader.GetInt32(0);
            string _description = reader.GetString(1);
            string _finalDate = reader.GetDateTime(2).ToString();
            routine = new RoutinesEx(_id_routine,_description,_finalDate);
            UnityEngine.Debug.Log("[SelectRoutineFromID]"+ _id_routine);
        }
        reader.Close();
        return routine;
    }
}