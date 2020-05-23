using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
public class ExerciseDao{

    public string insertExercise(Exercise ex,MySqlConnection connection){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText ="";
        return null;
    }

}