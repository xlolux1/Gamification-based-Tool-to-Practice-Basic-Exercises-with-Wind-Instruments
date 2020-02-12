using System;
using System.Collections.Generic;
public  class ScaleExercise  : Exercise
{
    enum Scales {Mayor,Menor}

    public enum Intervals {semitono=1,tono}

    
    public string firstNote;
    private Scales scaleType;

    public Intervals[] intervals1 = new Intervals[7];
    private int[] intervals= new int[7]{2,2,1,2,2,2,1};

    public int duration;

    public List<Intervals> intervalos;

    public ScaleExercise(){
        
    }

    public ScaleExercise(string tune, int beats, string timeSignature,string firstNote,List<String> intervals,int duration):base(tune,beats,timeSignature){
        this.firstNote = firstNote;
        this.duration = duration;
        createScale();
    }
     public override string ToString()
   {
      return "Scale[Tune:"+tune+" beats:"+beats+" timeSignature:"+timeSignature+" firstNote"+firstNote+"]";
   }

   private void  setIntervals(List<String> string_intervals){
       int counter = 0;
       foreach (var interval in string_intervals) {
           Intervals inter ;
           if(interval.Equals("tono")){
                inter = Intervals.tono;
           }else{
                inter = Intervals.semitono;
           }
           intervals1[counter] = inter;
           counter ++;
        }

   }



       public  void createScale(){
        
        string[] words = firstNote.Split(' ');
        string initialNote = words[0];
        UnityEngine.Debug.Log ("initial: "+ initialNote);
        string intString = words[1];
        int numberScale = 0;
        if (!Int32.TryParse(intString, out numberScale))
        {
            numberScale = -1;
        }
         int sum = 0;
         int midi = NoteToMidi(initialNote ,numberScale);
        for(int i = 0; i<=7;i++){
            List<double> midiDuration = new List<double>();
            
            if(i!=0){
                UnityEngine.Debug.Log ("interval: "+ intervals[i-1]);
                sum = sum + (int)intervals[i-1];

            }
            UnityEngine.Debug.Log ("sum: "+ sum);
           int midiBase = midi;
           midiBase = midiBase + sum;
           UnityEngine.Debug.Log ("midiBase: "+ midiBase);
           Note not =new Note();
           not.midi = midiBase;
           Durations f =(Durations)duration;
           not.duration =  f;
           

           midiDuration.Add(midiBase);
           midiDuration.Add(duration);
           list_midisdurations.Add(midiDuration);
           list_notes.Add(not);
        }
        
    }


}