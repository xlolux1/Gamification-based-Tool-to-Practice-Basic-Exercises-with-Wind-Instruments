using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class StatisticsModeScript : MonoBehaviour{
    private string instrument;
    private string username;
    public TMP_Text textNumberRoutines;
    public TMP_Text textNumberExercises;
    public TMP_Text textNumberNotes;
    public TMP_Text textNumberExercisesPlayed;

    public GameObject statisticsMenu;

    public GameObject chooseMode;

    public void setStatistics(string _username,string _instrument){
        this.username = _username;
        this.instrument = _instrument;
        this.textNumberRoutines.text = this.calculateNumberRoutines(this.username,this.instrument).ToString();
        this.textNumberExercises.text = this.calculateNumberExercises(this.username,_instrument).ToString();
    }

    private int calculateNumberRoutines(string _username,string _instrument){
         int numberRoutines = Manager.Instance.getNumberRoutinesProfile(_username,_instrument);
         return numberRoutines;
    }
    private int calculateNumberExercises(string _username,string _instrument){
        int numberExercises = Manager.Instance.getNumberExercises(_username,_instrument);
        return numberExercises;
    }

    public void goBack(){
        this.statisticsMenu.SetActive(false);
        this.chooseMode.SetActive(true);
    }


}
