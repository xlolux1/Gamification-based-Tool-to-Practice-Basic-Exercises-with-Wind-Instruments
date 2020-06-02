using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

using SimpleJSON;

public class JsonParser
{
    ExerciseFactory factory= new ExerciseFactory();
    public JsonParser(){

    }



    public Exercise LoadJson5(){
        string the_JSON_string = System.IO.File.ReadAllText(@"C:\Users\anton\Ejercicio3.JSON");

        var json = JSON.Parse(the_JSON_string);
        var type = json["type"].Value;        // versionString will be a string containing "1.0"
        var name = json["Exercise"]["ExerciseType"].Value;
        UnityEngine.Debug.Log("Class[JsonParser] method [LoadJson5] Creating json"+ json+" "+name);
        Exercise ex = null;
        switch(type){
        
            case "Exercise":
            ex = this.factory.GetExercise(name,json["Exercise"]);
            break;
        }
        return ex;
    }

    public RoutinesEx readRoutine(){
        List<Exercise> listExercises= new List<Exercise>();
        List<ScaleExercise> listScales = new List<ScaleExercise>();
        string the_JSON_string = System.IO.File.ReadAllText(@"C:\Users\anton\Routine.JSON");
        var json = JSON.Parse(the_JSON_string);
        UnityEngine.Debug.Log("Class[JsonParser] method [readRoutine] Creating json"+ the_JSON_string);
        UnityEngine.Debug.Log("Class[JsonParser] method [readRoutine] Creating json"+ json);
        string type = json["type"].Value;
        UnityEngine.Debug.Log("Class[JsonParser] method [readRoutine] Creating type"+ type);
        string description ="";
        string finalDate= "";
        if(type.Equals("Routine")){
             description = json["description"].Value;
             finalDate = json["finalDate"].Value;

        }
        bool continu=true;
        int counter = 1;
        while(continu){
            Exercise exercise = null;
            string ex=counter.ToString();
            string typeEx =json[ex]["ExerciseType"].Value;
            if(typeEx.Equals("") || typeEx.Equals(null)){
                UnityEngine.Debug.Log("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
                continu= false;

            }else{
                exercise =factory.GetExercise(typeEx,json[ex]);
                UnityEngine.Debug.Log("GET TYPE"+ exercise.GetType());
                listExercises.Add(exercise);
                if(typeEx.Equals("Scale")){
                    UnityEngine.Debug.Log("DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
                    listScales.Add(factory.scale);
                }
            }
            counter++;
        }
        RoutinesEx routine = new RoutinesEx(description,finalDate,0);
        routine.listExercises = listExercises;
        routine.listScales = listScales;
        return routine;
    }
}