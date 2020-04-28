using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
public  class NormalExercise  : Exercise{
    private string minimumPitch;
    private string maxPitch;
    private Durations maxDuration;
    private Durations minimumDuration;

    private int numberNotes;

        public NormalExercise(string tune, int beats, string timeSignature,
        string maxPitch,string minPitch,int minDuration,int maxDuration):base(tune,beats,timeSignature){
    }

}