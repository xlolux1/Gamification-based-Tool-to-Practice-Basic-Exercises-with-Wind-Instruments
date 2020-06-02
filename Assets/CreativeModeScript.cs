using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class CreativeModeScript : MonoBehaviour{
    private string username;
    private string profile;
    public GameObject creativeMode;
    public GameObject chooseMode;
    public GameObject createScale;
    public TMP_Dropdown selectExercise;
    private int creativeRoutineId;

    public void setUserProfile(string _username, string _profile){
        this.username = _username;
        this.profile = _profile;
        this.getCreativeRoutine();
        this.setExercises();
    }

    public  void setExercises(){
        List<string> listDescriptions = new List<string>();

        List<Tuple<int, string>> listExercisesDescription = Manager.Instance.
        getExerciesFromRoutine(this.username,this.profile,this.creativeRoutineId);
        for (int i=0;i<listExercisesDescription.Count;i++){
            UnityEngine.Debug.Log("[PRUEBA DECRIPTIONS]"+listExercisesDescription[i].Item2);
            
           listDescriptions.Add(listExercisesDescription[i].Item2);
        }
        this.selectExercise.ClearOptions();
        this.selectExercise.AddOptions(listDescriptions);
    }
    private void getCreativeRoutine(){
        UnityEngine.Debug.Log("[Get creative Routine UI:]"+this.username+this.profile);
        this.creativeRoutineId = Manager.Instance.getCreativeRoutine(this.username,this.profile);
    }

    public void selectExerciseButton(){
       string response = Manager.Instance.GetExercise(selectExercise.value);
       UnityEngine.Debug.Log(response);
    }


    public void createScaleButton(){
        this.creativeMode.SetActive(false);
        this.createScale.GetComponent<CreateScaleScript>().setScale(this.username,this.profile,creativeRoutineId);
        this.createScale.SetActive(true);
    }

}
