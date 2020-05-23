using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreateScaleScript : MonoBehaviour{
    public TMP_InputField firstNoteField;
    public TMP_InputField beatsField;

    public TMP_Dropdown scaleTypeField;
    public TMP_Dropdown durationField;

    public TMP_Dropdown signatureField;

    private string scaleType = "MayorScale";
    private int duration = 1;
    private string signature = "4/4";

    private string tune ="SiB";



    public void handleScaleTypeField(int value){
        if(value == 0){
            this.scaleType ="MayorScale";

        }else if( value == 1){
            this.scaleType="MinorScale";
        }
    }

    public void handleDurationField(int value){
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

    public void handleSignatureField(int value){
        if(value == 0){
            this.signature = "4/4";
        }else if (value == 1){
            this.signature = "3/4";
        }else if (value == 2){
            this.signature ="2/4";
        }
    }

    public void createScale(){
        string beats = beatsField.text;
        string firstNote = firstNoteField.text;
        Manager.Instance.createScale(this.tune,this.signature,beats,this.scaleType,firstNote,this.duration);
    }    

}
