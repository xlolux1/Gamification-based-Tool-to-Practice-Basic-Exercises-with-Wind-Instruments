using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using SimpleJSON;
public class ExerciseDao{

    private static readonly HttpClient client = new HttpClient();

/*
    public string insertExercise(MySqlConnection connection,Exercise ex){
        MySqlCommand cmd = connection.CreateCommand();
        string descriptionMessage = "[Exercise]: Signature:"+ex.timeSignature+" Beats:"+ex.beats;
        cmd.CommandText ="INSERT INTO Exercise(idExercise,difficulty,description,tune,signature,beats) Values("+ex.idExercise+",'"+
        ex.difficulty+"','"+descriptionMessage+"','"+ex.tune+"','"+ex.timeSignature+"',"+ex.beats+");";
        MySqlDataReader reader = cmd.ExecuteReader();
        reader.Close();
        return null;
    }
*/
    public string insertExerciseM(Exercise exercise){
        var values = new Dictionary<string, string>
        {
            { "idExercise", exercise.idExercise.ToString() },
            { "difficulty", exercise.difficulty },
            { "description", exercise.description },
            { "tune", exercise.tune },
            { "timeSignature", exercise.timeSignature },
            { "beats", exercise.beats.ToString() },

        };
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/insertExercise.php", content).Result;
         string resultContent = response.Content.ReadAsStringAsync().Result;
        return resultContent;
    }
/*
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
    */
    public int getCountExercisesM(){
        var values = new Dictionary<string, string>();
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/getCountExercises.php", content).Result;
         string resultContent = response.Content.ReadAsStringAsync().Result;
        return Int16.Parse(resultContent);

    }

    public Exercise getExerciseFromIdM(int id){
        Exercise ex = null;
        var values = new Dictionary<string, string>
        {
            { "idExercise", id.ToString() }
        };
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/getExerciseFromId.php", content).Result;
         string resultContent = response.Content.ReadAsStringAsync().Result;
        var json = JSON.Parse(resultContent);
        int _idExercise =Int16.Parse(json["idExercise"]);
        string _difficulty =json["difficulty"];
        string _description =json["description"];
        string _tune = json["tune"];
        string _signature =json["signature"];
        int _beats =Int16.Parse(json["beats"]);
        ex = new Exercise(_idExercise,_difficulty,_description,_tune,_signature,_beats);
        return ex;
    }
/*
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
*/ 

}