using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;
public class LoginMenu : MonoBehaviour{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public TMP_Text errorText;
    public Button  loginButton;

    public GameObject loginMenu;
    public GameObject profileMenu;
    public GameObject sucessfulPanel;

    public GameObject registerMenu;


    private string username;
    private string error;


    public string getUserName(){
        return username;
    }
    public void prueba(){
            loginMenu.SetActive(false);

            profileMenu.SetActive(true);
        
    }


    public void Login(){
        this.errorText.text = "in Login";
        string username = usernameField.text;
        string password = passwordField.text;
              this.errorText.text = "in Login1";
        if(username!= "" && password !=""){
            this.errorText.text = "in Login2";
            UnityEngine.Debug.Log("[LOGIN] " +"username:"+username+ " password:"+password);
            this.errorText.text = "in Login3";
            string response ="HI";
            try{
             response = Manager.Instance.Login(username,password);
            }catch(Exception e){
                this.errorText.text =e.ToString();
            }
            UnityEngine.Debug.Log("[LOGIN] " +response);
            if(response.Equals("OK")){
                UnityEngine.Debug.Log("[LOGIN] " +"FFFFFFFFFFFFFFFFF");
                this.username = username;
                loginMenu.SetActive(false);
                this.setProfileMenu();
                profileMenu.SetActive(true);
            }else{
               //this.errorText.text;
            }
        }
    }


    public void setProfileMenu(){
        profileMenu.GetComponent<profileScript>().setUsernameTxt(this.username);
        profileMenu.GetComponent<profileScript>().setInstrumentsCreated();
    }
        public void goRegister(){
            this.usernameField.text="";
            this.passwordField.text="";
            loginMenu.SetActive(false);

            registerMenu.SetActive(true);
    }

    public void setReadOnly(bool boolean){
        this.usernameField.readOnly= boolean;
        this.passwordField.readOnly = boolean;
    }
    public void closeApplication(){
        Manager.Instance.manConnection.closeConnection();
         Application.Quit();
    }


}
