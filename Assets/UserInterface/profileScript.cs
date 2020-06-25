using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class profileScript : MonoBehaviour{
    public GameObject loginMenu;
    public GameObject profileMenu;
    public GameObject chooseMode;
   private  TMP_Dropdown selectInstrumentDropdown;
    public TMP_Dropdown listInstrumentsDropdown;
    private string instrument;
    private string username;
    public Image firstImageBlue;
    public Image secondImageBlue;
    public Image firstImageGrey;
    public Image secondImageGrey;

    public TMP_Text firstLetterText;
    public TMP_Text userText;
    public Button logOutButton;
    public GameObject userInfo;
    public GameObject logOut;

    private bool userBox = true;




    private string message;



    public  void setInstrumentsCreated(){
   /*     List<string> listInstruments = new List<string>();
        listInstruments = Manager.Instance.getInstrumentsPlayer();
        selectInstrumentDropdown.ClearOptions();
        selectInstrumentDropdown.AddOptions(listInstruments);
        */
    }
        void Start()
    {
        if(Manager.Instance.currentPlayer == null){
            this.goBack();

        }else{
            this.username = Manager.Instance.currentPlayer.username;
            this.setUsernameTxt(this.username);
            this.setInstrumentsCreated();

        }
    }





    public void setUsernameTxt(string username){
        this.username = username;
        this.userText.text =username;
        this.firstLetterText.text = username[0].ToString().ToUpper();
        this.logOut.SetActive(false);
    }

    public void createNewProfile(string instrument){
        string response = Manager.Instance.createProfile(instrument);
        if (response.Equals("Error")){
            this.message= "can't create this Profile";
        }
        this.setInstrumentsCreated();
    }
    public void closeApp(){
        Application.Quit();
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
