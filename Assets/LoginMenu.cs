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
    public void Login(){
        string username = usernameField.text;
        string password = passwordField.text;
        UnityEngine.Debug.Log("[LOGIN] " +"username:"+username+ " password:"+password);
         bool response = Manager.Instance.Login(username,password);
         if(response){
            loginMenu.SetActive(false);
            profileMenu.SetActive(true);
         }
       

    }
        public void goRegister(){
            loginMenu.SetActive(false);

            registerMenu.SetActive(true);
    }


}
