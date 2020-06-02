using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class profileScript : MonoBehaviour{
    public GameObject loginMenu;
    public GameObject profileMenu;
    public GameObject chooseMode;
    public TMP_Text usernameField;
    public TMP_Dropdown selectInstrumentDropdown;
    public TMP_Dropdown listInstrumentsDropdown;
    private string instrument;
    private string username;

    private string message;



    public  void setInstrumentsCreated(){
        List<string> listInstruments = new List<string>();
        listInstruments = Manager.Instance.getInstrumentsPlayer();
        selectInstrumentDropdown.ClearOptions();
        selectInstrumentDropdown.AddOptions(listInstruments);
    }





    public void setUsernameTxt(string username){
        this.usernameField.text = "Profile:" + username;
        this.username = username;

    }

    public void createNewProfile(string instrument){
        string response = Manager.Instance.createProfile(instrument);
        if (response.Equals("Error")){
            this.message= "can't create this Profile";
        }
        this.setInstrumentsCreated();
    }
    public void selectProfile(){
        this.instrument = selectInstrumentDropdown.options[selectInstrumentDropdown.value].text;
        if(Manager.Instance.selectProfile(this.instrument)){
            this.profileMenu.SetActive(false);
            this.setChooseMode();
            this.chooseMode.SetActive(true);
        }
    }

    private void setChooseMode(){
        chooseMode.GetComponent<chooseModeScript>().setTittle(this.username,this.instrument);
    }

    public void goBack(){
        this.profileMenu.SetActive(false);
        this.loginMenu.SetActive(true);

    }








}
