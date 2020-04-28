using System;
public  class LongNotesExercise  : Exercise{
    private string note;
    private Durations duration;
    private int numberNotes;

        public LongNotesExercise(string tune, int beats, string timeSignature,string note,int duration ,int numberNotes):base(tune,beats,timeSignature){
            this.note = note;
            this.numberNotes = numberNotes;
            try{
                this.duration = (Durations)duration;

            }catch(Exception){
                
            }
            
            createLongNotesExercise();
    }
    private void createLongNotesExercise(){
        char scale = this.note[-1];
        string scaleString = scale.ToString();
        int scaleInt = int.Parse(scaleString);
        int midiFirstNote = NoteToMidi(this.note,scaleInt);
        
        Random rnd = new Random();

        for(int i = 0; i<numberNotes;i++){
                 int random  = rnd.Next(0, 6);
                 Note  nextNote = new Note();
                 nextNote.midi = midiFirstNote + random;
                 nextNote.duration = this.duration;
                 nextNote.dotted = false;
                 list_notes.Add(nextNote);
        }
    }
}