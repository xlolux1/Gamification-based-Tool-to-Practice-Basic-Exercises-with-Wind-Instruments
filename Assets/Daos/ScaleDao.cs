using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using SimpleJSON;

public class ScaleDao  : ExerciseDao{
 private static readonly HttpClient client = new HttpClient();

    public string insertScale(MySqlConnection connection,ScaleExercise scale){
        //this.insertExercise(connection,scale);
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText="INSERT INTO ScaleExercise(idExercise,typeScale,firstNote,duration) Values("+scale.idExercise+",'"
        +scale.scaleTypes+"','"+scale.firstNote+"','"+scale.duration+"');";
        MySqlDataReader reader = cmd.ExecuteReader();
        reader.Close();
        return null;
    }

    public string insertScaleM(ScaleExercise scale){
        this.insertExerciseM(scale);
                var values = new Dictionary<string, string>
        {
            { "idExercise", scale.idExercise.ToString() },
            { "scaleTypes", scale.scaleTypes },
            { "firstNote", scale.firstNote },
            { "duration", scale.duration.ToString() }

        };
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/insertScale.php", content).Result;
         string resultContent = response.Content.ReadAsStringAsync().Result;
         UnityEngine.Debug.Log(resultContent);
        return resultContent;
    }

/*
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
*/

    public bool isScaleM(int idExercise){
        bool isScale = false;
        var values = new Dictionary<string, string>
        {
            { "idExercise", idExercise.ToString()},
        };
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/isScale.php", content).Result;
        string resultContent = response.Content.ReadAsStringAsync().Result;
         if(Int16.Parse(resultContent) == 1){
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