

using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

/*********************************************************************
*
* Class Name: ExerciseFactory
* Author/s name: Antonio Pulido Hernánzed
* Class description: This class implements the method Factory
* design pattern in order to create differnt types of exercises
**********************************************************************
*/ 

public class ExerciseFactory{
    public ScaleExercise scale;
    public LongNotesExercise longNotes;
    public Exercise GetExercise(string type,JSONNode json){
        Exercise ex = null;
        UnityEngine.Debug.Log("Class[ExerciseFactory]"+json);

        switch(type){
            case "Scale":
                var exercise = json["Scale"];
                UnityEngine.Debug.Log("Class[ExerciseFactory]"+json);
                ScaleExercise scale =createScale(exercise);
                this.scale =scale;
                ex = scale;
                break;
            case "LongNotesExercise":
                var exerciseLong = json["LongNotesExercise"];
                LongNotesExercise longNotes = createLongNotesExercise(exerciseLong);
                ex = longNotes;
                break;
            case "normalExercise":
                var exerciseNormal = json["normalExercise"];
                break;
        }
        ex.getStringNotes();
        return ex;
    }
    private  ScaleExercise createScale(JSONNode json){
        int beats = json["beats"].AsInt;
        UnityEngine.Debug.Log("Class[ExerciseFactory] beats"+beats);
        var tune = json["tune"].Value;
        var timeSignature =json["timeSignature"].Value;
        var firstNote =json["firstNote"].Value;
        var scaleType = json["scaleType"];
        var duration = json["duration"];
       // List<String> intervalsList = getIntervalScale(intervals);
        ScaleExercise ExerciseScale =new ScaleExercise(tune,beats,timeSignature,firstNote,scaleType,duration);
        UnityEngine.Debug.Log(ExerciseScale.ToString());
        ExerciseScale.getStringNotes();
        return ExerciseScale;
    }
    private  LongNotesExercise createLongNotesExercise(JSONNode json){
    int beats = json["beats"].AsInt;
    var tune = json["tune"].Value;
    var timeSignature =json["timeSignature"].Value;
    var note =json["note"].Value;
    var duration = json["duration"];
    var numberNotes = json["numberNotes"];
    LongNotesExercise longNotes =new LongNotesExercise(tune,beats,timeSignature,note,duration,numberNotes);
    UnityEngine.Debug.Log("Class[ExerciseFactory] + method [createLongNotesExercise" + longNotes.ToString());
    return longNotes;
}

    private List<string> getIntervalScale(JSONNode json){
        List<string> intervalsList = new List<string>();
        for(int i =0; i<=6;i++){
            string interval =json[i];
            intervalsList.Add(interval);
        }
        return intervalsList;

    }
    
}