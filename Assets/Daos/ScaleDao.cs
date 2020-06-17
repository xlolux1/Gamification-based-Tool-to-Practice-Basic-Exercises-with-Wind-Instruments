using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;

public class ScaleDao  : ExerciseDao{

    public string insertScale(MySqlConnection connection,ScaleExercise scale){
        this.insertExercise(connection,scale);
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText="INSERT INTO ScaleExercise(idExercise,typeScale,firstNote,duration) Values("+scale.idExercise+",'"
        +scale.scaleTypes+"','"+scale.firstNote+"','"+scale.duration+"');";
        MySqlDataReader reader = cmd.ExecuteReader();
        reader.Close();
        return null;
    }

    public bool isScale(MySqlConnection connection,int idExercise){
        bool isScale= false;
        int count =-1;
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText="Select count(*) from ScaleExercise Where idExercise="+idExercise+";";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
             count = reader.GetInt32(0);
        }
        reader.Close();
        if(count == 1){
            isScale = true;
        }
        return isScale;
    }
    public ScaleExercise getScale(MySqlConnection connection, int idScale,Exercise ex){
        UnityEngine.Debug.Log("GET SCALE"+idScale);
        ScaleExercise scale = null;
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText="Select * from ScaleExercise Where idExercise="+idScale+";";
        MySqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read()){
            string typeScale = reader.GetString(1);
            string firstNote = reader.GetString(2);
            int duration = reader.GetInt32(3);
            UnityEngine.Debug.Log("GET SCALE"+ typeScale);
            scale = new ScaleExercise(ex.tune,ex.beats,ex.timeSignature,firstNote,typeScale,duration);
        }
        reader.Close();
        return scale;
    }
}