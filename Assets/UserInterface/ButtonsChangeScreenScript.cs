using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsChangeScreenScript : MonoBehaviour{
    public GameObject creativeMode;
    public GameObject practiceMode;
    public GameObject statisticsMode;
    public GameObject chooseMode;
    private string username;
    private string instrument;
    

    public void setProfile(string _username,string _instrument){
        this.username = _username;
        this.instrument = _instrument;
    }


    public void openStatistics(){
        this.creativeMode.SetActive(false);
        this.practiceMode.SetActive(false);
        this.setStatistics(this.username,this.instrument);
        this.statisticsMode.SetActive(true);
        this.chooseMode.SetActive(false);

    }
    public void openPracticeMode(){
        this.setPracticeMode(this.username,this.instrument);
        this.creativeMode.SetActive(false);
        this.practiceMode.SetActive(true);
        this.statisticsMode.SetActive(false);
        this.chooseMode.SetActive(false);

    }
    public void openCreativeMode(){
        this.statisticsMode.SetActive(false);
        this.setCreativeMode(this.username,this.instrument);
        this.creativeMode.SetActive(true);
        this.practiceMode.SetActive(false);
        this.chooseMode.SetActive(false);
        
    }
        private void setStatistics(string _username,string _instrument){
        statisticsMode.GetComponent<StatisticsModeScript>().setStatistics(_username,_instrument);
    }
    private void setPracticeMode(string _username,string _profile){
        practiceMode.GetComponent<practiceModeScript>().setPracticeMode(_username,_profile);
    }
    private void setCreativeMode(string _username,string _profile){
        creativeMode.GetComponent<CreativeModeScript>().setUserProfile(_username,_profile);
    }

}
