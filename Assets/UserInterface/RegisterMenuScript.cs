using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class RegisterMenuScript : MonoBehaviour{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public TMP_InputField nameField;
    public TMP_InputField surnameField;
    public TMP_InputField emailField;
    public GameObject loginMenu;
    public GameObject RegisterMenu;
    public Button  registerButton;
    public void Register(){
        string username = usernameField.text;
        string password = passwordField.text;
        string name = nameField.text;
        string surname = surnameField.text;
        string email = emailField.text;
        if(username!= "" && password !="" && name!="" && surname !="" && email!=""){
                    string response = Manager.Instance.Register(username,password,name,surname,email);
            UnityEngine.Debug.Log("[REGISTER MENU SCRIPT]:"+response);
            if(response =="OK"){
                RegisterMenu.SetActive(false);
                loginMenu.SetActive(true);
            }
        }


    }

    public void goBack(){
            RegisterMenu.SetActive(false);
            this.usernameField.text="";
            this.nameField.text="";
            this.surnameField.text="";
            this.emailField.text="";
            this.passwordField.text="";
            loginMenu.SetActive(true);
    }




}
