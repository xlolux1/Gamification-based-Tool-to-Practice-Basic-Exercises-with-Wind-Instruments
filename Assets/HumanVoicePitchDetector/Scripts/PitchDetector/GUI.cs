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
		float y = -0.8745f;
		float yDistance = 0.2349f;
	GameObject quaver;
    GameObject noteImage;

    float positionXNext;
     float notesXDistance;


     public GUI(){

     }

    public void drawMusicStaff(){

    }

	public float calculatePostion(float xComponent){
		
		return x + xComponent*2;
	}
	/*
    public void drawScala(Exercise exercise,GameObject noteImage){
      /*  GameObject newNote = UnityEngine.Object.Instantiate<GameObject> (noteImage);
        newNote.transform.position = new Vector3 (2,2);
        

		for (int i = 0; i < exercise.list_midisdurations.Count; ++i) {

			x = x + 2;
			float value = midiToScreenCustomY(exercise.list_midisdurations[i][0]);
            UnityEngine.Debug.Log ("Y: "+ value);

			
			GameObject newNote = UnityEngine.Object.Instantiate<GameObject> (noteImage);
			newNote.transform.position = new Vector3 (x, value);
		}

    }
	*/

	public void getNoteType(Exercise.Note note){


	}
	public void drawNote(int midi,int duration,GameObject noteImage,GameObject quaver,float position){
		this.noteImage = noteImage;
		this.quaver = quaver;
		float xComponent = calculatePostion(position);
			float value= midiToScreenCustomY(midi);
            UnityEngine.Debug.Log ("Y: "+ value);
			GameObject image = getTypeofNote(duration);

			
			GameObject newNote = UnityEngine.Object.Instantiate<GameObject> (image);
			newNote.transform.position = new Vector3 (xComponent, value);

	}
	 private  GameObject getTypeofNote(int duration){
		 GameObject game =null;
		switch(duration){
			case 4:
			game = noteImage;
			break;
			case 8:
			game = quaver;
			break;
		}
		return game;

	}



public enum Pitchs{Mi = 0, Fa = 1, FaS =2, Sol = 3, SolS = 4 ,La = 5, LaS =6, Si = 7, Do =8, DoS = 9, Re = 10, ReS =11}
    private float midiToScreenCustomY(int midiNote){
		
		var mi4 = 50; //Si Bemol
		float dif = midiNote - mi4;
		float resto = dif % 12;
		float div = (int)dif / 12;

		Pitchs foo = (Pitchs)resto;
		float newY = 0.0f;
UnityEngine.Debug.Log ("Midiiiiiii Y Custom: "+ midiNote +foo);
		switch(foo){
			case Pitchs.Mi:
				newY = 0;
				break;

			case Pitchs.Fa:
				newY = yDistance;

			break;
			case Pitchs.FaS:
				newY =yDistance;
				break;
			case Pitchs.Sol:
				newY =yDistance*2f;

			break;

			case Pitchs.SolS:
				newY = yDistance*2f;
				break;
			case Pitchs.La:
			newY = yDistance*3f;

			break;

			case Pitchs.LaS:
				newY =yDistance*3f;
				break;
			case Pitchs.Si:
			newY =yDistance*4f;

			break;
			case Pitchs.Do:
			newY =yDistance*5f;
				break;
			case Pitchs.DoS:
			newY =  yDistance*5f;

			break;
			case Pitchs.Re:
			newY = yDistance*6f;
				break;

			case Pitchs.ReS:
			newY = yDistance*6f;
				break;

		}
		newY =( (y + newY)+ (yDistance *(div *7)));
		UnityEngine.Debug.Log ("MidiNote: "+ midiNote + " Pitch :"+foo +" "+"New Y:"+newY + " y:"+y +" diff:"+dif+" reso:"+resto+" div"+div);
		return newY;		
	}

		
		
		

}