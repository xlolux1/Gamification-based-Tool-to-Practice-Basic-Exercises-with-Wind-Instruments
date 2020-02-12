using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

using SimpleJSON;

public class ExerciseFactory{
    public Exercise GetExercise(string type,JSONNode json){
        Exercise ex = null;
        switch(type){
            case "Scale":
                var exercise = json["Scale"];
                
                ScaleExercise scale =createScale(exercise);
                ex = scale;
                break;
            case "LongNotesExercise":
                var exerciseLong = json["LongNotesExercise"];
                LongNotesExercise longNotes = createLongNotesExercise(exerciseLong);
                ex = longNotes;
                break;
        }
        ex.getStringNotes();
        return ex;

    }
    private  ScaleExercise createScale(JSONNode json){
    int beats = json["beats"].AsInt;
    var tune = json["tune"].Value;
    var timeSignature =json["timeSignature"].Value;
    var firstNote =json["firstNote"].Value;
    var intervals = json["intervals"];
    var duration = json["duration"];
    List<String> intervalsList = getIntervalScale(intervals);
    ScaleExercise ExerciseScale =new ScaleExercise(tune,beats,timeSignature,firstNote,intervalsList,duration);
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
    UnityEngine.Debug.Log(longNotes.ToString());
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