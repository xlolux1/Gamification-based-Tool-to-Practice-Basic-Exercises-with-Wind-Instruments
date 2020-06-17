
using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
public class RoutineExerciseDao{
    public string insertRoutineExercise(MySqlConnection connection,int routineId,Exercise exercise){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText ="INSERT INTO ExercisesInRoutines(idRoutine,idExercise) Values("+routineId+","+exercise.idExercise+");";
        MySqlDataReader reader = cmd.ExecuteReader();
        reader.Close();
        return null;
    }
    public List<int> getExerciesFromRoutine(MySqlConnection connection,int routineId){
        UnityEngine.Debug.Log("Reading RoutineID from ExercisesInRoutines"+routineId);
        MySqlCommand cmd = connection.CreateCommand();
        List<int> listIds = new List<int>();
        cmd.CommandText ="Select idExercise from ExercisesInRoutines Where idRoutine="+routineId+";";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
            int id = reader.GetInt32(0);
            UnityEngine.Debug.Log("Reading RoutineID from ExercisesInRoutines"+id);
            listIds.Add(id);
        }
        reader.Close();
        return listIds;
    }
        public List<Tuple<int, string>>  getExerciesDescriptionFromRoutine(MySqlConnection connection,RoutinesEx routine){
        MySqlCommand cmd = connection.CreateCommand();
        List<Tuple<int, string>>  listExercises = new List<Tuple<int, string>>();
        List<int> listIds = new List<int>();
        cmd.CommandText ="Select idExercise from ExercisesInRoutines Where idRoutine="+routine.id+";";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
            int id = reader.GetInt32(0);
            UnityEngine.Debug.Log("Reading RoutineID from ExercisesInRoutines"+id);
            listIds.Add(id);
        }
        reader.Close();
        listExercises = this.getDescriptionsListIdExercises(connection,listIds);
        
        return listExercises;
    }

    private List<Tuple<int, string>> getDescriptionsListIdExercises(MySqlConnection connection, List<int> listIds){
        List<Tuple<int, string>>  exercises = new List<Tuple<int, string>>();

        for(int i=0; i<listIds.Count; i++){
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText ="Select description from Exercise Where idExercise="+listIds[i]+";";
             MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()){
                string description = reader.GetString(0);
                Tuple<int, string> exercise = new Tuple <int, string>(listIds[i], description);
                exercises.Add(exercise);
            }
            reader.Close();
        }
        
        return exercises;
    }
    public int getNumberExercisesFromIdRoutine(MySqlConnection connection,int idRoutine){
        MySqlCommand cmd = connection.CreateCommand();
        int count = 0;
        cmd.CommandText ="Select count(*) from ExercisesInRoutines Where idRoutine="+idRoutine+";";
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()){
             count = reader.GetInt32(0);
        }
        reader.Close();
        return count;

    }

}