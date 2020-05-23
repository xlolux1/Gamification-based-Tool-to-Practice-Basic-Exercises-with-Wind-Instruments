using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;

public class ScaleDao{



    public string insertRoutine(MySqlConnection connection,ScaleExercise scaleExerices){
        MySqlCommand cmd = connection.CreateCommand();

        cmd.CommandText="Select count(*) from Exercise;";

        cmd.CommandText= "INSERT INTO Exercise(idExercise,tune,signature,beats) Values ('"+1+"',";


        cmd.CommandText= "INSERT INTO Routines(idRoutine,description,days) Values("+routine.id+","+
        routine.description+","+routine.days+");";
        MySqlDataReader reader = cmd.ExecuteReader();
        return null;
    }
}