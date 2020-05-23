using System;
using System.Collections;
using System.Collections.Generic;
public class RoutinesEx{
    public int id;
    public string description;
    public int days;


    List<Exercise> listExercises;

    public RoutinesEx(int _id, string _description,int _days){
        this.id = _id;
        this.description = _description;
        this.days = _days;
    }
    public RoutinesEx(string _description,int _days){
        this.description = _description;
        this.days = _days;

    }
}