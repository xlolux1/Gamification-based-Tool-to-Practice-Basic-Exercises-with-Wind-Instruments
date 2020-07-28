using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Managers;
using Managers;
using UnityEngine.UI;

public class StatisticsModeScript : MonoBehaviour{
    private string instrument;
    private string username;
    public TMP_Text textNumberRoutines;
    public TMP_Text textProfile;
    public TMP_Text textNumberExercises;
    public TMP_Text textNumberNotes;
    public TMP_Text textNumberExercisesPlayed;
    public TMP_Text firstLetterText;
    public TMP_Text userText;
    public Button logOutButton;
    public GameObject userInfo;
    public GameObject logOut;
    private bool userBox = true;
    public GameObject statisticsMenu;

    public GameObject chooseMode;

    public void setStatistics(string _username,string _instrument){
        this.username = _username;
        this.instrument = _instrument;
        this.textProfile.text = this.instrument +" profile";
        this.textNumberRoutines.text = this.calculateNumberRoutines(this.username,this.instrument).ToString();
        this.textNumberExercises.text = this.calculateNumberExercises(this.username,_instrument).ToString();
        this.userText.text =username;
        this.firstLetterText.text = username[0].ToString().ToUpper();
        this.logOut.SetActive(false);
    }
    public void closeApp(){
        Application.Quit();
    }

    private int calculateNumberRoutines(string _username,string _instrument){
         int numberRoutines = Manager.Instance.getNumberRoutinesProfile(_username,_instrument);
         return numberRoutines;
    }
    private int calculateNumberExercises(string _username,string _instrument){
        //int numberExercises = Manager.Instance.getNumberExercises(_username,_instrument);
        return Manager.Instance.getInstrumentsPlayer().Count;
    }

    public void goBack(){
        this.statisticsMenu.SetActive(false);
        this.chooseMode.SetActive(true);
    }
        public void changeUserLogOut(){
        if(userBox){
            this.userInfo.SetActive(false);
            this.logOut.SetActive(true);
            this.userBox = false;
        }else{
            this.logOut.SetActive(false);
            this.userInfo.SetActive(true);
            this.userBox = true;
        }
        
    }
    

}
