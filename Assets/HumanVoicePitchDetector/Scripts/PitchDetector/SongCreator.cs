using System;
using System.Collections.Generic;



static class Constants{
    public const int Do3 = 58;
    public const int Re_3 = 59;
    public const int Re3 = 60;
    public const int Mi_3 = 61;
    public const int Mi3=62;
    public const int Fa3=63;
    public const int Sol_3=64;
    public const int Sol3=65;
    public const int La_3=66;
    public const int La3=67;
    public const int Si_3=68;

    public const int Si3 = 69;

    public const int Do4 =70;




}
public class SongCreator {


    public Song createSong1(){
        Song song=new Song();
        
        song.list_midisdurations.Add(createNote(Constants.Do3,4));
        song.list_midisdurations.Add(createNote(Constants.Re3,4));
        song.list_midisdurations.Add(createNote(Constants.Mi3,4));
        song.list_midisdurations.Add(createNote(Constants.Fa3,4));
        song.list_midisdurations.Add(createNote(Constants.Sol3,4));
        song.list_midisdurations.Add(createNote(Constants.La3,4));
        song.list_midisdurations.Add(createNote(Constants.Si3,4));
        song.list_midisdurations.Add(createNote(Constants.Do4,4));

        return song;



    }
    private List<double> createNote(double midi, double duration){
        var note = new List<double>();
        note.Add(midi);
        note.Add(duration);

        return note;

    }
}