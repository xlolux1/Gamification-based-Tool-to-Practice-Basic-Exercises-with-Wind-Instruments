using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using SimpleJSON;
public class ProfiDao{

 private static readonly HttpClient client = new HttpClient();


    public string insertProfileM(string username,string instrument){
        var values = new Dictionary<string, string>
        {
            { "user", username },
            { "instrument", instrument },
        };
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/insertProfile.php", content).Result;
         string resultContent = response.Content.ReadAsStringAsync().Result;
        return resultContent;
    }
    /*
        public string insertProfile(MySqlConnection connection,Player newPlayer,string instrument){
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText ="INSERT INTO Profi(username,instrument) Values('"+newPlayer.username+"','"+
            instrument+"')";
            MySqlDataReader reader = cmd.ExecuteReader();
             reader.Close();
        return null;
    }
    */
/*
    public List<string> getInstruments(MySqlConnection connection,Player currentPlayer){
         List<string> listInstruments = new List<string>();
        MySqlCommand cmd = connection.CreateCommand();
        
        cmd.CommandText = "SELECT instrument FROM Profi Where username='"+currentPlayer.username+"';";
        
        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read()){
            string _instrument = reader.GetString(0);
            listInstruments.Add(_instrument);
        }
        reader.Close();
        return listInstruments;
    }
    */
    public List<string> getInstrumentsM(Player currentPlayer){
        var values = new Dictionary<string, string>
        {
            { "user", currentPlayer.username }
        };
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/getInstruments.php", content).Result;
         string resultContent = response.Content.ReadAsStringAsync().Result;
        var json = JSON.Parse(resultContent);
        return null;
    }

    public int selectProfile(MySqlConnection connection,Player currentPlayer,string instrument){
        int count = -1;
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT count(*) FROM Profi Where username='"+currentPlayer.username+"' AND instrument='"+instrument+"';";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
             count = reader.GetInt32(0);
        }
        reader.Close();
        return count;
    }
    public int selectProfileM(string username,string instrument){
        var values = new Dictionary<string, string>
        {
            { "user", username },
            { "instrument", instrument }
        };
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/selectProfile.php", content).Result;
         string resultContent = response.Content.ReadAsStringAsync().Result;
        return Int16.Parse(resultContent);
    }
}