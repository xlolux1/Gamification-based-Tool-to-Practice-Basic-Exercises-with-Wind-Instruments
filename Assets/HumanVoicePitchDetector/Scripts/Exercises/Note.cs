    public class Note{
    public int midi;
    public Durations duration;
    public bool dotted;
    public float percentageNote;

    public Note(int _midi,Durations _durations,bool _dotted){
        this.midi = _midi;
        this.duration = _durations;
        this.dotted = _dotted;
    }

    public void setPercentageNote(float rightPitch,float totalPitch){
        this.percentageNote = rightPitch/totalPitch;
    }
}