using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

using SimpleJSON;

public class JsonParser
{
    public JsonParser(){

    }



public Exercise LoadJson5(){
    string the_JSON_string = System.IO.File.ReadAllText(@"C:\Users\anton\Ejercicio3.JSON");

    var json = JSON.Parse(the_JSON_string);
    var type = json["type"].Value;        // versionString will be a string containing "1.0"
    var name = json["Exercise"]["ExerciseType"].Value;
UnityEngine.Debug.Log("Creating json"+ json+" "+name);
    Exercise ex = null;
    switch(type){
        
        case "Exercise":
        ExerciseFactory factory= new ExerciseFactory();
         ex = factory.GetExercise(name,json["Exercise"]);
        break;
    }
    return ex;






}
}