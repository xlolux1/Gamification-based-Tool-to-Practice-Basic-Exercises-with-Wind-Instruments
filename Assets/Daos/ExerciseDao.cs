using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
public class ExerciseDao{

    public string insertExercise(MySqlConnection connection,Exercise ex){
        MySqlCommand cmd = connection.CreateCommand();
        string descriptionMessage = "[Exercise]: Signature"+ex.timeSignature;
        cmd.CommandText ="INSERT INTO Exercise(idExercise,difficulty,description,tune,signature,beats) Values("+ex.idExercise+",'"+
        ex.difficulty+"','"+descriptionMessage+"','"+ex.tune+"','"+ex.timeSignature+"',"+ex.beats+");";
        MySqlDataReader reader = cmd.ExecuteReader();
        reader.Close();
        return null;
    }

    public int getCountExercises(MySqlConnection connection){
        MySqlCommand cmd = connection.CreateCommand();
         cmd.CommandText = "Select Count(*) From Exercise;";
         int count = -1;
         MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
             count = reader.GetInt32(0);
        }
        reader.Close();
        return count;
    }
    
    public Exercise getExerciseFromId(MySqlConnection connection,int id){
        Exercise ex = null;
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "Select * From Exercise Where idExercise="+id+";";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
            int idExercise = reader.GetInt32(0);
            string difficulty = reader.GetString(1);
            string description = reader.GetString(2);
            string tune = reader.GetString(3);
            string signature = reader.GetString(4);
           int beats = reader.GetInt32(5);
            ex = new Exercise(idExercise,difficulty,description,tune,signature,beats);


        }
        reader.Close();
        return ex;
    }

}