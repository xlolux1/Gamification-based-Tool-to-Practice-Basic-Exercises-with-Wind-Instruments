using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public class controlScript : MonoBehaviour
{
    public GameObject control;
            public void FinishExercise(){
            SceneManager.LoadScene(0);
        }
}
