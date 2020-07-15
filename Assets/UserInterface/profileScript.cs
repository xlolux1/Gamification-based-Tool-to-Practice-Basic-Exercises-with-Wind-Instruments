using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Managers;
public class profileScript : MonoBehaviour{
    public GameObject loginMenu;
    public GameObject profileMenu;
    public GameObject chooseMode;
   private  TMP_Dropdown selectInstrumentDropdown;
    public TMP_Dropdown listInstrumentsDropdown;
    private string instrument;
    private string username;

    public TMP_Text firstLetterText;
    public TMP_Text userText;
    public Button logOutButton;
    public GameObject userInfo;
    public GameObject logOut;

    private bool userBox = true;




    private string message;

    public void setButtonsSelect(){
       GameObject prueba = Instantiate(this.userInfo);
       prueba.transform.Translate(0,120,120);
    }



        void Start()
        
    {
        if(Manager.Instance.currentPlayer == null){
            this.goBack();

        }else{
            this.username = Manager.Instance.currentPlayer.username;
            this.setUsernameTxt(this.username);

        }
    }





    public void setUsernameTxt(string username){
        this.username = username;
        this.userText.text =username;
        this.firstLetterText.text = username[0].ToString().ToUpper();
        this.logOut.SetActive(false);
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



    public void selectProfile(string _instrument){
        this.instrument = _instrument;
        if(Manager.Instance.selectProfile(this.instrument)){
            this.profileMenu.SetActive(false);
            this.setChooseMode();
            this.chooseMode.SetActive(true);
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
