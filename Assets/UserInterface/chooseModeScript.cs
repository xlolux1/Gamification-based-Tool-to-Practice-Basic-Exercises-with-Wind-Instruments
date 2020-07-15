using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Managers;
public class chooseModeScript : MonoBehaviour{

    public TMP_Text titleField;
    public GameObject chooseExerciseType;
    public GameObject profileMenu;
    public GameObject chooseMode;
    public GameObject practiceMode;
    public GameObject statisticsMode;
    public GameObject clarinetBackground;
    public GameObject trumpetBackground;
    public GameObject tubaBackground;
    public GameObject FlugelHornBackground;
    public GameObject buttonsChangeScreen;

    public TMP_Text firstLetterText;
    public TMP_Text userText;
    public Button logOutButton;
    public GameObject userInfo;
    public GameObject logOut;
    public TMP_Text titleText;
    private bool userBox = true;
    

    private string username;
    private string instrument;

        public void setTittle(string _username,string _instrument){
            this.username = _username;
            this.instrument = _instrument;
            
            this.setBackground();
            this.buttonsChangeScreen.GetComponent<ButtonsChangeScreenScript>().setProfile(username,instrument);
            this.buttonsChangeScreen.SetActive(true);
            this.userText.text =username;
            this.firstLetterText.text = username[0].ToString().ToUpper();
            this.logOut.SetActive(false);
        }

    public void openCreativeMode(){
            chooseMode.SetActive(false);
            this.setCreativeMode(this.username,this.instrument);
            chooseExerciseType.SetActive(true);

    }

    private void setCreativeMode(string _username,string _profile){
                UnityEngine.Debug.Log("DEBUG "+_username +_profile);
        chooseExerciseType.GetComponent<CreativeModeScript>().setUserProfile(_username,_profile);
    }


    public void openPracticeMode(){
        chooseMode.SetActive(false);
        this.setPracticeMode(this.username,this.instrument);
        practiceMode.SetActive(true);
    }
    private void setPracticeMode(string _username,string _profile){
        practiceMode.GetComponent<practiceModeScript>().setPracticeMode(_username,_profile);
    }

    public void openStatisticsMode(){
        chooseMode.SetActive(false);
        this.setStatistics(this.username,this.instrument);
        this.statisticsMode.SetActive(true);
    }
    private void setStatistics(string _username,string _instrument){
        statisticsMode.GetComponent<StatisticsModeScript>().setStatistics(_username,_instrument);
    }
    private void setBackground(){
        switch (this.instrument){
            case "clarinet":
                this.clarinetBackground.SetActive(true);
                this.titleText.text = "clarinet profile";
                break;
            case "trumpet":
                this.titleText.text = "trumpet profile";
                this.trumpetBackground.SetActive(true);
                break;
            case "tuba":
                this.titleText.text = "tuba profile";
                this.tubaBackground.SetActive(true);
                break;
            case "flugelhorn":
                this.titleText.text = "trombone profile";
                this.FlugelHornBackground.SetActive(true);
                break;
          default:
              UnityEngine.Debug.Log("Error profile");
              break;
      }
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



    public void goBack(){
        chooseMode.SetActive(false);
        profileMenu.SetActive(true);
    }
}
