using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class CreateScaleScript : MonoBehaviour{
    public TMP_InputField beatsField;

    public TMP_Dropdown scaleTypeField;
    public TMP_Dropdown durationField;

    public TMP_Dropdown signatureField;
    public TMP_Dropdown firstNoteField;
    public TMP_Dropdown firstNoteScaleField;
    public Slider beatSlider;

    private string scaleType = "Mayor Scale";
    private int duration = 1;
    private string signature = "4/4";

    private string tune ="SiB";


    private string username;
    private string instrument;
    private int creativeId;
    private string firstNote;
    private int firstNoteScale;
    public GameObject creativeMode;
    public GameObject createScale;


    public void handleScaleTypeField(){
        int value= scaleTypeField.value;
        if(value == 0){
            this.scaleType ="Mayor Scale";

        }else if( value == 1){
            this.scaleType="Minor Scale";
        }
    }

    public void handleDurationField(){
        int value = this.durationField.value;
        UnityEngine.Debug.Log("firstnote"+ value);
        if(value == 0){
            this.duration = 1;
        }else if (value == 1){
            this.duration = 2;
            
        }else if(value == 2){
            this.duration = 4;
        }else if(value == 3){
            this.duration = 8;
        }else if(value == 4){
            this.duration = 16;
        }
    }

    public void handleSignatureField(){
        int value = this.signatureField.value;

        if(value == 0){
            this.signature = "4/4";
        }else if (value == 1){
            this.signature = "3/4";
        }else if (value == 2){
            this.signature ="2/4";
        }
    }

    public void handleFirstNoteField(){
        int value = firstNoteField.value;
     UnityEngine.Debug.Log("firstnote"+ value);
        switch (value){
          case 0:
            this.firstNote = "DO";
              break;
          case 1:
            this.firstNote = "RE";
              break;
          case 2:
            this.firstNote = "MI";
              break;
          case 3:
            this.firstNote = "FA";
              break;
          case 4:
            this.firstNote = "SOL";
              break;
          case 5:
            this.firstNote = "LA";
              break;
          case 6:
            this.firstNote = "SI";
              break;
      }
    }

    public void handleScaleNoteField(){
        int value = this.firstNoteScaleField.value;
        UnityEngine.Debug.Log("Value"+value);
        this.firstNoteScale = value +1;
    }

    public void createScales(){
        this.handleDurationField();
        this.handleFirstNoteField();
        this.handleScaleNoteField();
        this.handleSignatureField();
        this.handleScaleTypeField();
        UnityEngine.Debug.Log("firstnote"+this.firstNote +this.firstNoteScale);
        string firstNote = this.firstNote +" "+ this.firstNoteScale.ToString();
        int beats = int.Parse(this.beatsField.text);
        UnityEngine.Debug.Log("[SCALE]Tune:"+tune+" Signature:"+this.signature+" Scale:"+this.scaleType+" firstNote"+firstNote);
        Manager.Instance.createScale(this.tune,this.signature,beats,this.scaleType,firstNote,this.duration,this.username,this.instrument,this.creativeId);
        this.goBack();
    }


    public void setScale(string _username,string _instrument,int _creativeId){
        this.username = _username;
        this.instrument = _instrument;
        this.creativeId = _creativeId;
    }
    	public void ValueChangeCheck(){
		beatsField.text = beatSlider.value.ToString();
	}

    private void goBack(){
        this.createScale.SetActive(false);
        this.setCreativeMode(this.username,this.instrument);

        this.creativeMode.SetActive(true);  
    }
    private void setCreativeMode(string _username,string _profile){
        creativeMode.GetComponent<CreativeModeScript>().setUserProfile(_username,_profile);
    }

        

}
