using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
/*
public class LongNotesDao:ExerciseDao{
        public string insertLongNotes(MySqlConnection connection,LongNotesExercise longNOtes){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText="INSERT INTO ScaleExercise(idExercise,typeScale,firstNote,duration) Values("+scale.idExercise+",'"
        +scale.scaleTypes+"','"+scale.firstNote+"','"+scale.duration+"');";
        MySqlDataReader reader = cmd.ExecuteReader();
        reader.Close();
        return null;
    }

    public bool isLongNotes(MySqlConnection connection,int idExercise){
        bool isLongNotes= false;
        int count =-1;
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText="Select count(*) from ScaleExercise Where idExercise="+idExercise+";";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
             count = reader.GetInt32(0);
        }
        reader.Close();
        if(count == 1){
            isLongNotes = true;
        }
        return isLongNotes;
    }

}*/