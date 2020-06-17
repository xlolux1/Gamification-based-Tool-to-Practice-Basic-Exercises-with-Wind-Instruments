using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class sucessfulPanelScript : MonoBehaviour{
    private GameObject blockedGameObject;
    private GameObject successfulGameOBject;
    private string message;

    public void setSucessfulPanel(GameObject _blockedGameObject,GameObject _successfulGameObject, string _message){
        this.blockedGameObject =_blockedGameObject;
        this.successfulGameOBject =_successfulGameObject;
        this.message =_message;

    }
}
