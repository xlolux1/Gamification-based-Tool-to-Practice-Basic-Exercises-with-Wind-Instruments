using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LoginMenu : MonoBehaviour{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;

    public GameObject loginMenu;
    public GameObject profileMenu;

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
                this.usernameField.text="";
                this.usernameField.text="";
                this.setProfileMenu();
                profileMenu.SetActive(true);
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


}
