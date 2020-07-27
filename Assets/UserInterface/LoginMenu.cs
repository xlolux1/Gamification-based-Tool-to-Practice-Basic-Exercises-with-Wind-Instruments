using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;
using Managers;
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
        GameObject duplicate = Instantiate(this.profileMenu);
        
        string username = usernameField.text;
        string password = passwordField.text;
        string response ="";
        if(username!= "" && password !=""){
            response = Manager.Instance.Login(username,password);
            UnityEngine.Debug.Log("[LOGIN] " +response);
            if(response.Equals("User logged")){
                this.username = username;
                loginMenu.SetActive(false);
                this.setProfileMenu();
                profileMenu.SetActive(true);
            }else{
               this.errorText.text =response;
            }
        }else{
            this.errorText.text = "Fill all the fields";
        }
    }


    public void setProfileMenu(){
        profileMenu.GetComponent<profileScript>().setUsernameTxt(this.username);
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
         Application.Quit();
    }


}
