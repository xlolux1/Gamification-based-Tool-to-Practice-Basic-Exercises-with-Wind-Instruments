using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using PitchDetector;
using SimpleJSON;
using UnityEngine.UI;


public class GuiManager{
	private string[] notesPiano = new string[] {"DO","DO#","RE","RE#","MI","FA","FA#","SOL","SOL#","LA","LA#","SI"};
	float x = -Camera.main.orthographicSize * Camera.main.aspect + 4;
	float y = -0.955f;
	float yDistance = 0.2349f;
	GameObject quaver;
    GameObject noteImage;
	public List<GameObject> listGameObjects = new List<GameObject>();
    float positionXNext;
    float notesXDistance;

    public void drawMusicStaff(){

    }

	public Sprite getInitialSprite(Durations dur,String colour){
		Sprite sprit;
		sprit = null;
		UnityEngine.Debug.Log ("Class[GUI] Method [getInitialSprite] Duration Y: "+ dur);

		if(dur == Durations.Semibreve){
			switch (colour){
          	case "green":
              sprit = Resources.Load<Sprite>("Sprites/semibreve/GreenSemibreve");
              	break;
          	case "black":
              	sprit = Resources.Load<Sprite>("Sprites/semibreve/BlackSemibreve");
              	break;
			case "red":
				sprit = Resources.Load<Sprite>("Sprites/semibreve/RedSemibreve");
				break;
			case "yellow":
				sprit = Resources.Load<Sprite>("Sprites/semibreve/YellowSemibreve");
				break;
			}
		}else if( dur == Durations.Minim){
			
			switch (colour){
          	case "green":
              	sprit = Resources.Load<Sprite>("Sprites/minim/GreenMinim");
              	break;
          	case "black":
              	sprit = Resources.Load<Sprite>("Sprites/minim/BlackMinim");
              	break;
			case "red":
				sprit = Resources.Load<Sprite>("Sprites/minim/RedMinim");
				break;
			case "yellow":
				sprit = Resources.Load<Sprite>("Sprites/minim/YellowMinim");
				break;
			}
			
		}else if (dur == Durations.Crotchet){
						switch (colour){
          	case "green":
              	sprit = Resources.Load<Sprite>("Sprites/crotchet/GreenCrotchet");
              	break;
          	case "black":
              	sprit = Resources.Load<Sprite>("Sprites/crotchet/blackCrotchet");
              	break;
			case "red":
				sprit = Resources.Load<Sprite>("Sprites/crotchet/RedCrotchet");
				break;
			case "yellow":
				sprit = Resources.Load<Sprite>("Sprites/crotchet/YellowCrotchet");
				break;
			}

		}else if (dur == Durations.Quaver){
						switch (colour){
          	case "green":
              	sprit = Resources.Load<Sprite>("Sprites/quaver/GreenQuaver");
              	break;
          	case "black":
              	sprit = Resources.Load<Sprite>("Sprites/quaver/BlackQuaver");
              	break;
			case "red":
				sprit = Resources.Load<Sprite>("Sprites/quaver/RedQuaver");
				break;
			case "yellow":
				sprit = Resources.Load<Sprite>("Sprites/quaver/YellowQuaver");
				break;
			}
		}

	  return sprit;

	}

	public float calculatePostion(float xComponent){
		
		return x + xComponent*2;
	}
/*
    public void drawScala(Exercise exercise,GameObject noteImage){

		for (int i = 0; i < exercise.list_midisdurations.Count; ++i) {

			x = x + 2;
			float value = midiToScreenCustomY(exercise.list_midisdurations[i][0]);
        
		newNote.transform.position = new Vector3 (x, value);
			
		}

    }
	
*/

	public void drawNote(int midi,Durations duration,GameObject noteImage,GameObject quaver,float position){
		//prueba();
		this.noteImage = noteImage;
		this.quaver = quaver;
		float xComponent = calculatePostion(position);
		UnityEngine.Debug.Log ("Class[GUI] Method [drawNote] Midi Y: "+ midi);
		float value= midiToScreenCustomY(midi);
        UnityEngine.Debug.Log ("Class[GUI] Method [drawNote] Y: "+ value);
		Sprite noteSprite = getInitialSprite(duration,"black");
		GameObject newNote = new GameObject(); //Create the GameObject
        SpriteRenderer renderer = newNote.AddComponent<SpriteRenderer>();
        renderer.sprite = noteSprite;
		//UnityEngine.Object.Instantiate<GameObject> (newNote); 
		newNote.GetComponent<SpriteRenderer>().sprite = noteSprite;
		newNote.transform.localScale = new Vector3(2.34f,2.34f,0);
		newNote.transform.position = new Vector3 (xComponent, value);
		listGameObjects.Add(newNote);
		


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

	private int transformSignature(string signature){
		int variation = 0;
		switch(signature){
			case "SiB":
			variation = 1;
			break;
		}
		return variation;
	}



public enum Pitchs{Mi = 0, Fa = 1, FaS =2, Sol = 3, SolS = 4 ,La = 5, LaS =6, Si = 7, Do =8, DoS = 9, Re = 10, ReS =11}
    private float midiToScreenCustomY(int midiNote){
		
		var mi4 = 50; //Si Bemol
		float dif = midiNote - mi4;
		float resto = dif % 12;
		float div = (int)dif / 12;

		Pitchs foo = (Pitchs)resto;
		float newY = 0.0f;
//UnityEngine.Debug.Log ("Midiiiiiii Y Custom: "+ midiNote +foo);
		switch(foo){
			case Pitchs.Mi:
				newY = 0;
				break;

			case Pitchs.Fa:
				newY = this.yDistance;

			break;
			case Pitchs.FaS:
				newY = this.yDistance;
				break;
			case Pitchs.Sol:
				newY = this.yDistance * 2f;

			break;

			case Pitchs.SolS:
				newY = this.yDistance * 2f;
				break;
			case Pitchs.La:
				newY = this.yDistance * 3f;
				break;

			case Pitchs.LaS:
				newY = this.yDistance * 3f;
				break;
			case Pitchs.Si:
				newY = this.yDistance * 4f;
				break;

			case Pitchs.Do:
				newY = this.yDistance * 5f;
				break;

			case Pitchs.DoS:
				newY =  this.yDistance * 5f;
				break;

			case Pitchs.Re:
			newY = this.yDistance * 6f;
				break;

			case Pitchs.ReS:
				newY = this.yDistance * 6f;
				break;

		}
		newY =( (y + newY)+ (yDistance *(div *7)));
		UnityEngine.Debug.Log ("MidiNote: "+ midiNote + " Pitch :"+foo +" "+"New Y:"+newY + " y:"+y +" diff:"+dif+" reso:"+resto+" div"+div);
		return newY;		
	}

		
		
		

}