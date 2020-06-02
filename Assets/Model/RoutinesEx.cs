using System;
using System.Collections;
using System.Collections.Generic;
public class RoutinesEx{
    public int id;
    public string description;
    public string date;

    public int creative;


    public List<Exercise> listExercises=new List<Exercise>();
    public List<ScaleExercise> listScales= new List<ScaleExercise>();
    public List<LongNotesExercise> listLongNotes= new List<LongNotesExercise>();

    public RoutinesEx(int _id, string _description,string _date,int _creative){
        this.id = _id;
        this.description = _description;
        this.date = _date;
        this.creative = _creative;
    }

    public RoutinesEx(int _id, string _description,string _date){
        this.id = _id;
        this.description = _description;
        this.date = _date;
    }
    public RoutinesEx(string _description,string _date,int _creative){
        this.description = _description;
        this.date = _date;
        this.creative = _creative;

    }
}