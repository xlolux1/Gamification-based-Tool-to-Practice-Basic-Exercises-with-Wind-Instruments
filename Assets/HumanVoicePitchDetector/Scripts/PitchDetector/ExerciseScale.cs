using System;
using System.Collections.Generic;
public class ExerciseScale : ExerciseType
{
    
    public string FirstNote;
    public int duration;
    public ExerciseScale(string first,int beats,string tunning,int duration)
    :base(beats,tunning){
         this.FirstNote = first;
         this.duration = duration;
    }


}