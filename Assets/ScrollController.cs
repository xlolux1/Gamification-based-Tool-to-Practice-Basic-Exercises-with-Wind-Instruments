using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class ScrollController : MonoBehaviour
{
	// Public Variables
	public GameObject coinOriginal;
    public GameObject coinContainer;
    public TMP_Text[] newText;
    public GameObject panelRectTransform;
    private RectTransform  rectTransform;
    

	private int numExercises = 200;
    private List<GameObject> gameObjectList = new List<GameObject>();


    public void Start(){
        rectTransform= panelRectTransform.GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,numExercises*155);
        
        for(int i = 0; i<numExercises;i++){

            GameObject CoinClone = Instantiate(coinOriginal);
            CoinClone.name = "CoinClone-" + (i);
            CoinClone.transform.parent = coinContainer.transform;
            CoinClone.transform.localScale = new Vector3(1f, 1f, 1f);
            CoinClone.transform.position = new Vector3((coinOriginal.transform.position.x+350*i)-((this.numExercises*36.5f)*5),coinOriginal.transform.position.y,coinOriginal.transform.position.z);
            CoinClone.AddComponent<idScript>();
            CoinClone.GetComponent<idScript>().setExerciseId(i);
            
        }
        
                for(int i = 0; i<numExercises;i++){
            TMP_Text[] newText = GetComponentsInChildren<TMP_Text> ();
            newText[i+1].text =i.ToString();
            
        }
    }
    public void ExerciseClick(GameObject but){
        int id = but.GetComponent<idScript>().getId();
    }




}
