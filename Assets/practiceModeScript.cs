using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class practiceModeScript : MonoBehaviour{
    private string username;
    private string instrument;
    public TMP_Dropdown dropdownRoutines;
    public TMP_Dropdown selectExercise;
    List<Tuple<int, string>> listRoutinesDescription = new List<Tuple<int, string>>();



    public void setPracticeMode(string _username,string _instrument){
        this.username = _username;
        this.instrument = _instrument;
        this.getRoutines();
        this.setExercises();
    }
    private void getRoutines(){
        List<string> listDescriptions = new List<string>();
        listRoutinesDescription = Manager.Instance.getRoutinesPlayer(this.username,this.instrument);
        for (int i=0;i<listRoutinesDescription.Count;i++){
            UnityEngine.Debug.Log("[PRUEBA DECRIPTIONS]"+listRoutinesDescription[i].Item2);
            
           listDescriptions.Add(listRoutinesDescription[i].Item2);
        }
        this.dropdownRoutines.ClearOptions();
        this.dropdownRoutines.AddOptions(listDescriptions);
    }
    public  void setExercises(){
        int routineId = listRoutinesDescription[this.dropdownRoutines.value].Item1;
        UnityEngine.Debug.Log("[PRUEBA DECRIPTIONS ROUTINE ID]"+routineId);
        List<string> listDescriptions = new List<string>();

        List<Tuple<int, string>> listExercisesDescription = Manager.Instance.
        getExerciesFromRoutine(this.username,this.instrument,routineId);
        for (int i=0;i<listExercisesDescription.Count;i++){
            UnityEngine.Debug.Log("[PRUEBA DECRIPTIONS]"+listExercisesDescription[i].Item2);
            
           listDescriptions.Add(listExercisesDescription[i].Item2);
        }
        this.selectExercise.ClearOptions();
        this.selectExercise.AddOptions(listDescriptions);
    }
}
