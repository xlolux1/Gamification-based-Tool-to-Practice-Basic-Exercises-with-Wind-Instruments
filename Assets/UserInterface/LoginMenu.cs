using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class LoginMenu : MonoBehaviour{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
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


    public void Login(){
        string username = usernameField.text;
        string password = passwordField.text;
        if(username!= "" && password !=""){
            UnityEngine.Debug.Log("[LOGIN] " +"username:"+username+ " password:"+password);
            string response = Manager.Instance.Login(username,password);
            if(response.Equals("OK")){
                this.username = username;
                loginMenu.SetActive(false);
                this.setProfileMenu();
                profileMenu.SetActive(true);
                this.usernameField.text="";
                this.usernameField.text="";
            }else{
                this.error = response;
            }
        }
    }


    public void setProfileMenu(){
        profileMenu.GetComponent<profileScript>().setUsernameTxt(this.usernameField.text);
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
