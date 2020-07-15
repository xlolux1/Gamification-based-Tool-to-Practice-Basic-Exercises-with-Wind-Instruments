using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using Managers;
using Managers;
using UnityEngine.UI;

public class CreativeModeScript : MonoBehaviour{
    private string username;
    private string profile;
    public GameObject creativeMode;
    public GameObject chooseMode;
    public GameObject createScale;
    public GameObject longNotes;
    public TMP_Dropdown selectExercise;
    private int creativeRoutineId;
    public GameObject orginalGameobject;
    public GameObject coinContainer;
    public TMP_Text[] newText;
    public GameObject panelRectTransform;
    public TMP_Text firstLetterText;
    public TMP_Text userText;
    public Button logOutButton;
    public GameObject userInfo;
    public GameObject logOut;


    private RectTransform  rectTransform;
    private List<Tuple<int,string>> listExercisesDescription = new List<Tuple<int,string>>();
    private int numExercises;
    private List<GameObject> gameObjectList = new List<GameObject>();
    private List<string> listDescriptions;
    public void setUserProfile(string _username, string _profile){
        this.username = _username;
        this.profile = _profile;
        this.userText.text =username;
        this.firstLetterText.text = username[0].ToString().ToUpper();
        this.logOut.SetActive(false);
        this.getCreativeRoutine();
        this.setExercises();
    }

    public  void setExercises(){
         this.listDescriptions = new List<string>();

        this.listExercisesDescription = Manager.Instance.
        getExerciesFromRoutine(this.username,this.profile,this.creativeRoutineId);
        for (int i=0;i<this.listExercisesDescription.Count;i++){
            UnityEngine.Debug.Log("[PRUEBA DECRIPTIONS]"+this.listExercisesDescription[i].Item2);
            
           this.listDescriptions.Add(this.listExercisesDescription[i].Item2);
        }
        this.numExercises =this.listDescriptions.Count;
        this.scrollStart();
    }
    private void getCreativeRoutine(){
        UnityEngine.Debug.Log("[Get creative Routine UI:]"+this.username+this.profile);
        this.creativeRoutineId = Manager.Instance.getCreativeRoutine(this.username,this.profile);
    }

    public void selectExerciseButton(){
       string response = Manager.Instance.setCurrentExercise(this.listExercisesDescription[selectExercise.value].Item1);
       SceneManager.LoadScene(1);
       UnityEngine.Debug.Log(response);
    }


    public void createScaleButton(){
        this.creativeMode.SetActive(false);
        this.createScale.GetComponent<CreateScaleScript>().setScale(this.username,this.profile,creativeRoutineId);
        this.createScale.SetActive(true);
    }
        public void createLongNotes(){
        this.creativeMode.SetActive(false);
        this.longNotes.SetActive(true);
    }


        public void goBack(){
            this.creativeMode.SetActive(false);
            this.chooseMode.SetActive(true);
    }
    
    private void scrollStart(){
        rectTransform= panelRectTransform.GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,numExercises*155);
        
        for(int i = 0; i<numExercises;i++){

            GameObject cloneGameObject = Instantiate(orginalGameobject);
            cloneGameObject.name = "cloneGameObject-" + (i);
            cloneGameObject.transform.parent = coinContainer.transform;
            cloneGameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            cloneGameObject.transform.position = new Vector3((orginalGameobject.transform.position.x+350*i)-((this.numExercises*36.5f)*5),orginalGameobject.transform.position.y,orginalGameobject.transform.position.z);
            cloneGameObject.AddComponent<idScript>();
            cloneGameObject.GetComponent<idScript>().setExerciseId(i);
            gameObjectList.Add(cloneGameObject);
        }
        orginalGameobject.SetActive(false);
        
        for(int i = 0; i<numExercises;i++){
            TMP_Text[] newText = GetComponentsInChildren<TMP_Text> ();
            newText[i+5].text =listDescriptions[i];
        }
    }

    private void destroyButtonsExercise(){
        for(int i=0;i<this.gameObjectList.Count;i++){
            
        }
    }
    public void ExerciseClick(GameObject but){
        int id = but.GetComponent<idScript>().getId();
        UnityEngine.Debug.Log(id);
    }

}
