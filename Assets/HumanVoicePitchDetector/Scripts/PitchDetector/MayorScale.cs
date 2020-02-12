using System;
using System.Collections.Generic;

public class MayorScale : ExerciseScale 
{
    // 2 = 2 semitonos
    // 1 = 1 Semitono
    private int[] tones= new int[7]{2,2,1,2,2,2,1};
    public List<List<double>> list_midisdurations = new List<List<double>>();


    public MayorScale(string first,int beats,string tunning,int duration):base(first,beats,tunning,duration){

        
    }
    public  void createMayorScale(){
        
        string[] words = FirstNote.Split(' ');
        string initialNote = words[0];
        string intString = words[1];
        int numberScale = 0;
        if (!Int32.TryParse(intString, out numberScale))
        {
            numberScale = -1;
        }
         int sum = 0;
         double midi = NoteToMidi(initialNote ,numberScale);
        for(int i = 0; i<=7;i++){
            List<double> midiDuration = new List<double>();
            
            if(i!=0){
                sum = sum + tones[i-1];

            }
           double midiBase = midi;
           midiBase = midiBase + sum;
           midiDuration.Add(midiBase);
           midiDuration.Add(duration);
           list_midisdurations.Add(midiDuration);
        }
        
    }
    
}

