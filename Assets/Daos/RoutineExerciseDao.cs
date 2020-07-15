
using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using SimpleJSON;
public class RoutineExerciseDao{
    private static readonly HttpClient client = new HttpClient();

    /*
    public string insertRoutineExercise(MySqlConnection connection,int routineId,Exercise exercise){
        MySqlCommand cmd = connection.CreateCommand();
        cmd.CommandText ="INSERT INTO ExercisesInRoutines(idRoutine,idExercise) Values("+routineId+","+exercise.idExercise+");";
        MySqlDataReader reader = cmd.ExecuteReader();
        reader.Close();
        return null;
    }
    */
    public string insertRoutineExerciseM(int routineId,Exercise exercise){
        var values = new Dictionary<string, string>
        {
            { "idRoutine", routineId.ToString() },
            { "idExercise", exercise.idExercise.ToString() }

        };
        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/insertRoutineExercise.php", content).Result;
         string resultContent = response.Content.ReadAsStringAsync().Result;
         UnityEngine.Debug.Log(resultContent);
        return resultContent;

    
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

    /*
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
    */
    public List<Tuple<int, string>>  getExerciesDescriptionFromRoutineM(RoutinesEx routine){
        List<Tuple<int, string>>  listExercises = new List<Tuple<int, string>>();
        List<int> listIds = new List<int>();
                var values = new Dictionary<string, string>
        {
            { "idRoutine", routine.id.ToString()}
        };

        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/getExerciseIdFromRoutine.php", content).Result;
        string resultContent = response.Content.ReadAsStringAsync().Result;
        UnityEngine.Debug.Log(resultContent);
        if(!resultContent.Equals("No idExercise found")){
            resultContent = resultContent.Remove(resultContent.Length - 1, 1);  
            string[] resultSplit = resultContent.Split(',');
        for(int i=0;i<resultSplit.Length;i++){
            listIds.Add(Int16.Parse(resultSplit[i]));
        }
        
         listExercises = this.getDescriptionsListIdExercisesM(listIds);

        }

        return listExercises;

    }

/*
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
    */
    private List<Tuple<int, string>> getDescriptionsListIdExercisesM(List<int> listIds){
        List<Tuple<int, string>>  exercises = new List<Tuple<int, string>>();
        for(int i=0; i<listIds.Count; i++){
             var values = new Dictionary<string, string>
                {
                { "idExercise", listIds[i].ToString() },
                };

        var content = new FormUrlEncodedContent(values);
        var response =  client.PostAsync("http://192.168.1.37/UnityBackendTutorial/getDescriptionExercise.php", content).Result;
        string resultContent = response.Content.ReadAsStringAsync().Result;
        Tuple<int, string> exercise = new Tuple <int, string>(listIds[i], resultContent);
         exercises.Add(exercise);

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