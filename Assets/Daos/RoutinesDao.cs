
using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using SimpleJSON;
public class RoutinesDao{

    private static readonly HttpClient client = new HttpClient();
/*
    public string insertRoutine(MySqlConnection connection,RoutinesEx routine){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText= "INSERT INTO Routines(idRoutine,description,finalDate) Values("+routine.id+",'"+
        routine.description+"','"+routine.date+"');";

        MySqlDataReader reader = cmd.ExecuteReader();
        reader.Close();
        return null;
    } 
    */
    public string insertRoutineM(RoutinesEx routine){
         var values = new Dictionary<string, string>
        {
            { "idRoutine", routine.id.ToString() },
            { "description", routine.description},
            { "finalDate", routine.date},
        };
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/insertRoutine.php", content).Result;
        string resultContent = response.Content.ReadAsStringAsync().Result;
        return resultContent;
    }
    /*
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
    */
    public int getLastNumberRoutineM(){
        var values = new Dictionary<string, string>();
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/getLastNumberRoutine.php", content).Result;
         string resultContent = response.Content.ReadAsStringAsync().Result;
        return Int16.Parse(resultContent);
    }
/*
    public RoutinesEx selectRoutineFromID(MySqlConnection connection,int idRoutine){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "Select * From Routines Where idRoutine="+idRoutine+";";
        MySqlDataReader reader = cmd.ExecuteReader();
        RoutinesEx routine = null;
        while (reader.Read()){
            int _id_routine = reader.GetInt32(0);
            string _description = reader.GetString(1);
            string _finalDate = reader.GetDateTime(2).ToString();
            routine = new RoutinesEx(_id_routine,_description,_finalDate);
        }
        reader.Close();
        return routine;
    }
    */
    public RoutinesEx selectRoutineFromIDM(int idRoutine){
        var values = new Dictionary<string, string>
        {
            { "idRoutine", idRoutine.ToString() },
        };
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/getRoutineFromID.php", content).Result;
         string resultContent = response.Content.ReadAsStringAsync().Result;
        var json = JSON.Parse(resultContent);
        int _idRoutine = Int16.Parse(json["idRoutine"]);
        string _description =json["description"];
        string _finalDate =json["finalDate"];
        RoutinesEx routine = new RoutinesEx(_idRoutine,_description,_finalDate);
        return routine;
    }

}