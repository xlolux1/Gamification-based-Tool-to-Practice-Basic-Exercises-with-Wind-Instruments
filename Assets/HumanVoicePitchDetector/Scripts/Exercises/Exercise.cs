/*********************************************************************
*
* Class Name: Exercise
* Author/s name: Antonio Pulido Hernández
* Class description: Represents a musical exercise
*
**********************************************************************
*/ 
using System;
using System.Collections;
using System.Collections.Generic;

[Flags] public enum PetType
{
   Semibreve = 1, Minim = 2, Crotchet = 4, Quaver = 8, Semiquaver =16
};
public abstract class Exercise
{
    public string difficulty;
    public string[] notesPiano = new string[] {"DO","DO#","RE","RE#","MI","FA","FA#","SOL","SOL#","LA","LA#","SI"};
    public int midiInicial = 24;
    public string tune;
    public int beats;
    public string timeSignature;
    public List<Note> list_notes = new List<Note>();
    public Exercise(){
        
    }

    public Exercise(string tune,int beats,string timeSignature){
        this.tune = tune;
        this.beats = beats;
        this.timeSignature =  timeSignature;
    }
        public  int getBeatTimeSeconds(){
        return  Convert.ToInt32(1/(beats/60)*1000);
    }

    public int getSecondsofNote(int positionNote){
        return Convert.ToInt32(1/(beats/60)*1000)*positionNote;
    }

    public int NoteToMidi(string note,int numberScale){
        int midi = 0;
        for (int i = 0; i < notesPiano.Length; i++){
            if(notesPiano[i].Equals(note)){
               midi =  midiInicial + i + 12 * (numberScale - 1);
            }
        }
        return midi;
    }

    public void getStringNotes(){
         UnityEngine.Debug.Log("get String Notes");
                    foreach (Note i in list_notes)
            {
               UnityEngine.Debug.Log("DEBUG:" +"Midi:"+i.midi+"Duration:"+i.duration);
            }
    }
}
