using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using SimpleJSON;
public class ProfileRoutinesDao{
    private static readonly HttpClient client = new HttpClient();


/*
    public string insertProfileRoutine(RoutinesEx routine,Profile profile,MySqlConnection connection){
        MySqlCommand cmd = connection.CreateCommand();
                        UnityEngine.Debug.Log("INSERT INTO PlayerRoutines(idRoutine,creative,username,instrument) Values("+routine.id+","+
        routine.creative+","+ profile.username+","+profile.instrument+");");
        cmd.CommandText= "INSERT INTO PlayerRoutines(idRoutine,creative,username,instrument) Values("+routine.id+","+
        +routine.creative+",'"+ profile.username+"','"+profile.instrument+"');";
        MySqlDataReader reader = cmd.ExecuteReader();
        

        reader.Close();
        return null;
    }
    */
    public string insertProfileRoutineM(RoutinesEx routine,Profile profile){
                 var values = new Dictionary<string, string>
        {
            { "idRoutine", routine.id.ToString()},
            { "creative", routine.creative.ToString()},
            { "username", profile.username},
            { "instrument", profile.instrument},
        };
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/insertProfileRoutine.php", content).Result;
        string resultContent = response.Content.ReadAsStringAsync().Result;
        UnityEngine.Debug.Log(resultContent);
        return resultContent;
    }

/*
    public int getNumberRoutinesFromProfile(Profile profile,MySqlConnection connection){
        int count = 0;
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText= "Select Count(*) From PlayerRoutines Where username ='"+profile.username+"' AND instrument='"+profile.instrument+"' AND creative<>"+1+";";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
             count =reader.GetInt32(0);
        }
        reader.Close();
        return count;
    }
*/  
    public int getNumberRoutinesFromProfileM(Profile profile){
        var values = new Dictionary<string, string>
        {
            { "user", profile.username},
            { "instrument", profile.instrument},
        };
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/getNumberRoutinesFromProfile.php", content).Result;
        string resultContent = response.Content.ReadAsStringAsync().Result;
        return Int16.Parse(resultContent);

    
    }

    public List<RoutinesEx> getRoutinesProfile(Profile profile,MySqlConnection connection){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "Select * from PlayerRoutines Where username ='"+profile.username+"' AND instrument='"+profile.instrument+"';";
        MySqlDataReader reader = cmd.ExecuteReader();
        reader.Close();
        return null;

    }

/*
    public int getCreativeRoutine(Profile profile,MySqlConnection connection){
        int idCreative = -1;
    MySqlCommand cmd = connection.CreateCommand();
    UnityEngine.Debug.Log("Select idRoutine from PlayerRoutines Where username ='"+profile.username+"' AND instrument='"+profile.instrument+"' AND creative="+1+";");
    cmd.CommandText = "Select idRoutine from PlayerRoutines Where username ='"+profile.username+"' AND instrument='"+profile.instrument+"' AND creative="+1+";";
    MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()){
             idCreative = reader.GetInt32(0);
             UnityEngine.Debug.Log("GET CREATIVE idCreative"+idCreative);

        }
        reader.Close();      
    return idCreative;
    }
    */
    public int getCreativeRoutineM(Profile profile){
        var values = new Dictionary<string, string>
        {
            { "user", profile.username},
            { "instrument", profile.instrument},
        };
         UnityEngine.Debug.Log("Response:"+profile.username + profile.instrument);
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/getCreativeRoutine.php", content).Result;
       
        string resultContent = response.Content.ReadAsStringAsync().Result;
         UnityEngine.Debug.Log("Response:"+resultContent);
        return Int16.Parse(resultContent);
    }


    public List<int> getRoutinesIdProfileNoCreative(Profile profile,MySqlConnection connection){
        List<int> listIdRoutines = new List<int>();
        MySqlCommand cmd = connection.CreateCommand();
        UnityEngine.Debug.Log("Select * from PlayerRoutines Where username ='"+profile.username+"' AND instrument='"+profile.instrument+"' AND creative <> 1;");
        cmd.CommandText = "Select * from PlayerRoutines Where username ='"+profile.username+"' AND instrument='"+profile.instrument+"' AND creative <> 1;";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
            int idRoutine = reader.GetInt32(0);
            listIdRoutines.Add(idRoutine);
            UnityEngine.Debug.Log("ID routine"+idRoutine);
        }
        reader.Close();
        return listIdRoutines;

    }
        public List<int> getRoutinesIdProfile(Profile profile,MySqlConnection connection){
        List<int> listIdRoutines = new List<int>();
        MySqlCommand cmd = connection.CreateCommand();
        UnityEngine.Debug.Log("Select * from PlayerRoutines Where username ='"+profile.username+"' AND instrument='"+profile.instrument+"' AND creative <> 1;");
        cmd.CommandText = "Select * from PlayerRoutines Where username ='"+profile.username+"' AND instrument='"+profile.instrument+"';";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
            int idRoutine = reader.GetInt32(0);
            listIdRoutines.Add(idRoutine);
            UnityEngine.Debug.Log("ID routine"+idRoutine);
        }
        reader.Close();
        return listIdRoutines;

    }
}