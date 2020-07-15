using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idScript : MonoBehaviour
{
    private int id;
    public void setExerciseId(int _id){
        UnityEngine.Debug.Log("HI");
        this.id = _id;
    }
    public int getId(){
        return this.id;
    }
}
