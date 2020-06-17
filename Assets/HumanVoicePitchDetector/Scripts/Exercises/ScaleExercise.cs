using System;
using System.Collections.Generic;

/*********************************************************************
*
* Class Name: ScaleExercise
* Author/s name: Antonio Pulido Hernández
* Release/Creation date:
* Class version:
* Class description: A type of musical exercise
**********************************************************************
*/ 
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
    public  string scaleTypes;

    private List<string> intervalsMayorScale = new List<String>{ "tono", "tono", "semitono", "tono", "tono", "tono","semitono"};

    public ScaleExercise(){
        
    }

    public ScaleExercise(string tune, int beats, string timeSignature,string firstNote,string ScaleType,int duration)
    :base(tune,beats,timeSignature){
        this.firstNote = firstNote;
        this.duration = duration;
        this.scaleTypes = ScaleType;
        if(!Enum.IsDefined(typeof(Durations), duration)){

            throw new DurationException("Duration Exception"+duration); 
            
        }
        this.setIntervals(ScaleType);
        createScale();
    }

     public override string ToString(){
      return "Scale[Tune:"+tune+" beats:"+beats+" timeSignature:"+timeSignature+" firstNote"+firstNote+"]";
   }

   private void  setIntervals(string scaleType){
       List<String> string_intervals = null;
       if(scaleType.Equals("Mayor Scale")){
           string_intervals = intervalsMayorScale;
       }
       int counter = 0;
       foreach (var interval in string_intervals) {
           Intervals inter ;
           if(interval.Equals("tono")){
                inter = Intervals.tono;
           }else{
                inter = Intervals.semitono;
           }
           this.intervals1[counter] = inter;
           counter ++;
        }
   }

       public  void createScale(){
        string[] words = firstNote.Split(' ');
        string initialNote = words[0];
        UnityEngine.Debug.Log ("initial: "+ initialNote);
        string intString = words[1];
        int numberScale = 0;
        if (!Int32.TryParse(intString, out numberScale)){
            numberScale = -1;
        }
         int sum = 0;
         int midi = NoteToMidi(initialNote ,numberScale);
        for(int i = 0; i <= 7; i++ ){
            List<double> midiDuration = new List<double>();
            
            if(i != 0){
                sum = sum + (int)intervals[i-1];

            }
           int midiBase = midi;
           midiBase = midiBase + sum;
           UnityEngine.Debug.Log ("[Create scale]Midi note: "+ midiBase);
           Durations realDuration = (Durations)duration;
           Note not =new Note(midiBase,realDuration,false);
           midiDuration.Add(midiBase);
           midiDuration.Add(duration);
           list_notes.Add(not);
        }
    }
    
}
