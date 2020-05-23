
using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
public class Routines{



    public string insertRoutine(MySqlConnection connection,RoutinesEx routine){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText= "INSERT INTO Routines(idRoutine,description,days) Values("+routine.id+","+
        routine.description+","+routine.days+");";
        MySqlDataReader reader = cmd.ExecuteReader();
        return null;
    }
}