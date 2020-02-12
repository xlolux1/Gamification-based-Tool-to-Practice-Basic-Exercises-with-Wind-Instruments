using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using PitchDetector;
using SimpleJSON;


public class GUI{
	private string[] notesPiano = new string[] {"DO","DO#","RE","RE#","MI","FA","FA#","SOL","SOL#","LA","LA#","SI"};
	    float x = -Camera.main.orthographicSize * Camera.main.aspect + 2;
		float y = 0.76f;

    float positionXNext;
     float notesXDistance;


     public GUI(){

     }


    public static void drawNote(){
    }

    public void drawMusicStaff(){

    }

	public float calculatePostion(float xComponent){
		
		return x + xComponent*2;
	}
    public void drawScala(Exercise exercise,GameObject noteImage){
      /*  GameObject newNote = UnityEngine.Object.Instantiate<GameObject> (noteImage);
        newNote.transform.position = new Vector3 (2,2);
        */

		for (int i = 0; i < exercise.list_midisdurations.Count; ++i) {

			x = x + 2;
			y = midiToScreenCustomY(exercise.list_midisdurations[i][0]);
            UnityEngine.Debug.Log ("Y: "+ y);

			
			GameObject newNote = UnityEngine.Object.Instantiate<GameObject> (noteImage);
			newNote.transform.position = new Vector3 (x, y);
		}

    }
	public void drawNote(double midi,GameObject noteImage,float position){
		float xComponent = calculatePostion(position);
			y = midiToScreenCustomY(midi);
            UnityEngine.Debug.Log ("Y: "+ y);

			
			GameObject newNote = UnityEngine.Object.Instantiate<GameObject> (noteImage);
			newNote.transform.position = new Vector3 (xComponent, y);

	}




    private float midiToScreenCustomY(double midiNote){
		UnityEngine.Debug.Log ("midis: "+ midiNote);


		int intMidiNote = (int)midiNote;
		float mi4screen = 0.76f;
		float midiMi4 = 52 ;
		float midiNoteScreen = 0;


		



		if(intMidiNote>=midiMi4){
				var num = intMidiNote -midiMi4;
                UnityEngine.Debug.Log ("NUMS: "+ num);

				if(num ==3){
					num = 2;
				}if(num == 5){
					num =3;
				}if(num == 7){
					num =4;
				}if(num == 8){
                    num =5;
                }

			midiNoteScreen = mi4screen +  0.242f * (num);
		}else{
			var num = intMidiNote -midiMi4;
			if(num== -4){
				num = -2;
			}else if (num ==-2){
				num =-1;
			}

			midiNoteScreen = mi4screen +  0.242f * (num);
			

		}
		return midiNoteScreen;
	}

}