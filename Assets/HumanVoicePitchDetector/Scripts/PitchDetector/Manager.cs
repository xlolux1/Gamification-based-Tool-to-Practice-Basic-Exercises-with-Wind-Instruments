using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using PitchDetector;
using SimpleJSON;

public sealed class Manager{
    private JsonParser parser = new JsonParser();


    private GUI graphicalInterface = new GUI();
    private readonly static Manager singleton = new Manager();
 
    private Manager(){
    }
 
    public static Manager Instance{
        get{
            return singleton;
        }
    }

    public  Exercise startExercise(string path){
        Exercise exercise =parser.LoadJson5();
        exercise.getStringNotes();
       

       return exercise;
    }

    public void drawExercise(Exercise ejercicio){
        graphicalInterface.drawMusicStaff();
    }

    public void drawScala(Exercise exercise,GameObject noteImage,GameObject quaver){
        parser.LoadJson5();

        for (int i = 0; i < exercise.list_notes.Count; ++i) {
            var midi  = exercise.list_notes[i].midi;
            int duration = (int)exercise.list_notes[i].duration;

            graphicalInterface.drawNote(midi,duration,noteImage,quaver,i);
        }
        //graphicalInterface.drawScala(scale,noteImage);
    }
}