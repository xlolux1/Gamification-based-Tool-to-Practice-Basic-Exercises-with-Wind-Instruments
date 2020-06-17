using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public class GameMusicControl : MonoBehaviour
{
    public GameObject statisticsMenu;
    public void finishGame(){
        SceneManager.LoadScene(0);

    }
}
