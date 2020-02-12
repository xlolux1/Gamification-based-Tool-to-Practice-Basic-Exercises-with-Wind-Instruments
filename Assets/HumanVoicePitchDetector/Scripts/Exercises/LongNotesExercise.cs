public  class LongNotesExercise  : Exercise{
    private string note;
    private Durations duration;
    private int numberNotes;

        public LongNotesExercise(string tune, int beats, string timeSignature,string note,int duration,int numberNotes):base(tune,beats,timeSignature){
            this.note = note;
            this.numberNotes = numberNotes;
    }
}