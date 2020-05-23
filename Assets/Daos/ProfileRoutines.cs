using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
public class ProfileRoutines{



    public string insertProfileRoutine(RoutinesEx routine,Profile profile,MySqlConnection connection){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText= "INSERT INTO PlayerRoutines(idRoutine,username,instrument) Values("+routine.id+","+
        profile.username+","+profile.instrument+");";
        MySqlDataReader reader = cmd.ExecuteReader();
        return null;
    }

    public List<Exercise> getRoutinesProfile(Profile profile,MySqlConnection connection){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText = "Select * from PlayerRoutines Where username ='"+profile.username+"' AND instrument='"+profile.instrument+"';";
        return null;

    }
}