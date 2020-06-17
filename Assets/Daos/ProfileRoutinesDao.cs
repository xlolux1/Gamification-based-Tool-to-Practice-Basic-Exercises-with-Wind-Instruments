using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
public class ProfileRoutinesDao{



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

    public List<RoutinesEx> getRoutinesProfile(Profile profile,MySqlConnection connection){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "Select * from PlayerRoutines Where username ='"+profile.username+"' AND instrument='"+profile.instrument+"';";
        MySqlDataReader reader = cmd.ExecuteReader();
        reader.Close();
        return null;

    }

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