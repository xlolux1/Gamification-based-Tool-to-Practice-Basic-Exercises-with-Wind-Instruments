using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createLongNotes : MonoBehaviour
{
    public GameObject creativeMode;
    public GameObject createLongNote;

    
        public void goBack(){
            this.createLongNote.SetActive(false);
            this.creativeMode.SetActive(true);
    }
}
