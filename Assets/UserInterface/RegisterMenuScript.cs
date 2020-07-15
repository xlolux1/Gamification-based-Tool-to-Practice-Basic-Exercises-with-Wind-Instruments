using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Managers;


public class RegisterMenuScript : MonoBehaviour{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public TMP_InputField nameField;
    public TMP_InputField surnameField;
    public TMP_InputField emailField;
    public GameObject loginMenu;
    public GameObject RegisterMenu;
    public Button  registerButton;
    public TMP_Text errorText;
    public void Register(){
        string username = usernameField.text;
        string password = passwordField.text;
        string name = nameField.text;
        string surname = surnameField.text;
        string email = emailField.text;
        if(username!= "" && password !="" && name!="" && surname !="" && email!=""){
            string response = Manager.Instance.Register(username,password,name,surname,email);
            UnityEngine.Debug.Log("[REGISTER MENU SCRIPT]:"+response);
            if(response.Equals("New player created successfully")){
                this.createProfiles(username);
                RegisterMenu.SetActive(false);
                loginMenu.SetActive(true);
            }else{
                errorText.text = response;
            }
        }else{
            errorText.text = "Fill all the fields";
        }

    }
    private void createProfiles(string username){
        string response ="";
        response =Manager.Instance.createProfile(username,"trumpet");
        UnityEngine.Debug.Log("[REGISTER MENU Create Profiles]:"+response);
        response = Manager.Instance.createProfile(username,"tuba");
        UnityEngine.Debug.Log("[REGISTER MENU Create Profiles]:"+response);
        response = Manager.Instance.createProfile(username,"clarinet");
        UnityEngine.Debug.Log("[REGISTER MENU Create Profiles]:"+response);
        response = Manager.Instance.createProfile(username,"flugelhorn");
        UnityEngine.Debug.Log("[REGISTER MENU Create Profiles]:"+response);
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
