using System;
using System.Collections.Generic;

public class Song {
    public List<List<double>> list_midisdurations = new List<List<double>>();
 

    private double beats =80;


    public  int getBeatTimeSeconds(){
        return  Convert.ToInt32(1/(beats/60)*1000);
    }
}