using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class chooseModeScript : MonoBehaviour{

    public TMP_Text titleField;
    public GameObject chooseExerciseType;
    public GameObject profileMenu;
    public GameObject chooseMode;
    public GameObject practiceMode;

    private string username;
    private string instrument;

        public void setTittle(string _username,string _instrument){
            this.username = _username;
            this.instrument = _instrument;
        this.titleField.text = "User:" + username +" Profile:"+instrument;
    }

    public void openCreativeMode(){
            chooseMode.SetActive(false);
            this.setCreativeMode(this.username,this.instrument);
            chooseExerciseType.SetActive(true);

    }

    private void setCreativeMode(string _username,string _profile){
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



    public void goBack(){
        chooseMode.SetActive(false);
        profileMenu.SetActive(true);
    }
}
