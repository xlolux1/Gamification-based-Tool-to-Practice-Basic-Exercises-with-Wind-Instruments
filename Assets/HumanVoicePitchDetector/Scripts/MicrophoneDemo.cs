﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using PitchDetector;
using SimpleJSON;
public class MicrophoneDemo : MonoBehaviour {
	private GameObject staff;
	private Stopwatch watch = new Stopwatch();
	private int currentNote = 0;

	public MicrophonePitchDetector detector;
	public int maxMidi = 110;
	public int addnotes = 5;
	public int minMidi = 50;
	public GameObject noteIndicatorGreenPrefab;
    public GameObject noteIndicatorRedPrefab;
	public GameObject  noteIndicatorYellowPrefab;
	public GameObject noteImage;
	public GameObject corchea;

	public GameObject compas;

	public GameObject noteIndicatorBlankPrefab;

	private GameObject noteIndicatorPrefab;

	public GameObject noteTitlePrefab;

	private Exercise exercise;


	private float scrollSpeed = 1f;
	private float appTime = 0f;
	private float analysisTime = 0f;
	private const float secsPerScreen = 10f;
	private float dbThres = -40;

	private int counterRightPitchDetected = 0;
	private int counterTotalPitchDetected = 0;



	private Queue<Tuple<PitchTime,int>> drawQueue = new Queue<Tuple<PitchTime,int>> ();
	
private Tuple<int,int> coords = new Tuple<int,int>(100, 200);
	// Class that holds pitch value and its duration
	private class PitchTime {
		public PitchTime(float pitch, float dt) {
			this.pitch = pitch;

			this.dt = dt;
			UnityEngine.Debug.Log(this.dt);
		}
		public float pitch;
		public float dt;
	};

	public float DbThreshold {
		get {
			return dbThres;
		}
		set {
			dbThres = value;
		}
	}

	// set event handlers 
	void Start () {
	PopulateMusicSheet();
	noteIndicatorPrefab =noteIndicatorRedPrefab;

		if (detector == null) {
			UnityEngine.Debug.LogWarning ("Pitch detector not set in MicrophoneDemo");
			return;
		}
		#if LOG_PITCH
		detector.onPitchDetected.AddListener (LogPitch);
		#endif
		if (noteIndicatorPrefab != null) {
			detector.onPitchDetected.AddListener (DrawPitch);
		} else {
			UnityEngine.Debug.LogWarning ("Note indicator not set in MicrophoneDemo");
		}
		scrollSpeed = 2 * Camera.main.orthographicSize * Camera.main.aspect / secsPerScreen;
		AutoDestroy.Lifetime = 0.5f * secsPerScreen;
		PopulateNoteTitles ();
	}



	// Print pitch values to console
	public void LogPitch (List<float> pitchList, int samples, float db) {
		
		var midis = RAPTPitchDetectorExtensions.HerzToMidi (pitchList);
		UnityEngine.Debug.Log ("Class[MicrophoneDemo] method [LogPitch] detected " + pitchList.Count + " values from  " + samples + " samples, db:" + db);
		UnityEngine.Debug.Log (midis.NoteString ());
		Boolean green = false;
		Boolean yellow = false;
		
		
		 foreach (int number in midis){
			 counterTotalPitchDetected = counterTotalPitchDetected + 1;
			 UnityEngine.Debug.Log("MIDIS NUMBER: " +number);
			if(number!=exercise.list_notes[currentNote].midi && number != exercise.list_notes[currentNote].midi+1  && number != exercise.list_notes[currentNote].midi-1){
			}else if(number== exercise.list_notes[currentNote].midi+1 || number == exercise.list_notes[currentNote].midi-1){
				yellow = true;

			}else{
				counterRightPitchDetected = counterRightPitchDetected + 1;
				green = true;
			}

		 }

		 UnityEngine.Debug.Log ("Green: "+green+ "Yellow: "+yellow);
		 
        TimeSpan elapsed = watch.Elapsed;
		UnityEngine.Debug.Log ("Update Note: "+ watch.Elapsed.Milliseconds+exercise.list_notes[currentNote].duration);
		
	}

	// Set pitch values to draw queue
	public void DrawPitch(List<float> pitchList, int samples, float db) {
		var duration = (float)samples / (float)detector.micSampleRate;
		if (pitchList.Count > 0 && db > dbThres) {
			foreach (var pitchVal in pitchList) {
				var midis = RAPTPitchDetectorExtensions.HerzToMidi (pitchVal);
				UnityEngine.Debug.Log ("midis PRUEBA: "+ midis);
				drawQueue.Enqueue (new Tuple<PitchTime,int>(new PitchTime (pitchVal, duration / pitchList.Count),midis));
			}
		} else {
			drawQueue.Enqueue(new Tuple<PitchTime,int>(new PitchTime(0f, duration),0));
		}
	}

	// Get pitch values from queue and draw on screen
	void Update() {
		
		if(watch.Elapsed.Milliseconds+watch.Elapsed.Seconds*1000 >= 
		exercise.getBeatTimeSeconds()*(int)exercise.list_notes[currentNote].duration){
			watch.Stop();
			exercise.list_notes[currentNote].setPercentageNote(this.counterRightPitchDetected,this.counterTotalPitchDetected);
			UnityEngine.Debug.LogWarning ("Percentage Calculated: "+exercise.list_notes[currentNote].percentageNote);
			this.counterRightPitchDetected = 0;
			this.counterTotalPitchDetected = 0;
			UnityEngine.Debug.LogWarning ("Update Note: "+currentNote);
			currentNote = currentNote+1;
			if (currentNote ==exercise.list_notes.Count){
				currentNote = 0;
			}
			watch.Reset();
			watch.Start();

		}
		
		if (!detector.Record) {
			return;
		}
		appTime += Time.deltaTime;
		UnityEngine.Debug.LogWarning ("appTime: "+appTime +" analysisTime" + analysisTime);


		while (analysisTime < appTime && drawQueue.Count > 0) {
			var item = drawQueue.Dequeue ();
			var midi = RAPTPitchDetectorExtensions.HerzToFloatMidi (item.Item1.pitch);

			UnityEngine.Debug.LogWarning ("Item NOTE: "+item.Item2 + "CURRENT" + exercise.list_notes[currentNote].midi + " midi" +midi);
			
			if(item.Item2==exercise.list_notes[currentNote].midi && this.currentNote == 0){
				noteIndicatorPrefab=noteIndicatorGreenPrefab;
							 if(watch.Elapsed.Milliseconds==0){
				watch.Start();
			 }
			}else if(item.Item2==exercise.list_notes[currentNote].midi+1 || item.Item2==exercise.list_notes[currentNote].midi+1){
				noteIndicatorPrefab=noteIndicatorYellowPrefab;
			}else{
				noteIndicatorPrefab = noteIndicatorRedPrefab;
			}
			



  UnityEngine.Debug.LogWarning ("infinity?"+ midi);
			if (!float.IsInfinity(midi)) {
				float y = MidiToScreenY (midi);
				float x = analysisTime * scrollSpeed;
				UnityEngine.Debug.LogWarning ("noteIndicatorPrefab"+ noteIndicatorPrefab);
			

				GameObject newNote = Instantiate<GameObject> (noteIndicatorPrefab);
				newNote.transform.position = new Vector3 (x, y);
				newNote.transform.SetParent (transform, false);
			}
			analysisTime += item.Item1.dt;
		}

		MoveLeft (scrollSpeed * Time.deltaTime);
	}
		
	// Populate note titles to left side of the display
	private void PopulateNoteTitles() {
		if (noteTitlePrefab == null) {
			UnityEngine.Debug.LogWarning ("Note Title Prefab not set in MicrophoneDemo");
			return;
		}
		float x = -Camera.main.orthographicSize * Camera.main.aspect;
		for (int i = minMidi; i <= maxMidi + addnotes; ++i) {
			float y = MidiToScreenY ((float)i);
			GameObject newTitle = Instantiate<GameObject> (noteTitlePrefab);
			newTitle.transform.position = new Vector3 (x, y);
			newTitle.GetComponent<TextMesh> ().text = RAPTPitchDetectorExtensions.MidiToNote (i);
		}
	}
	private void PopulateMusicSheet(){
	/**	JsonParser parser = new JsonParser();
	 Scale exercise = parser.LoadJson2();
	 song1 = exercise;


		if (noteTitlePrefab == null) {
			UnityEngine.Debug.LogWarning ("Note Title Prefab not set in MicrophoneDemo");
			return;
		}
		float x = -Camera.main.orthographicSize * Camera.main.aspect;
		float y = 0.76f;
		for (int i = 0; i < song.list_midisdurations.Count; ++i) {

			x = x + 2;
			y = midiToScreenCustomY(song.list_midisdurations[i][0]);
			
			GameObject newNote = Instantiate<GameObject> (noteImage);
			newNote.transform.position = new Vector3 (x, y);
		
		}*/
		Exercise ex = Manager.Instance.startExercise();
		exercise = ex;
		Manager.Instance.drawScala(ex,noteImage,corchea);
		
	}

	private float MidiToScreenY(float midiVal) {
		if (float.IsInfinity (midiVal)) {
			midiVal = RAPTPitchDetectorExtensions.HerzToMidi (1f);
		}
		float viewHeight = 2 * Camera.main.orthographicSize;
		float dy = viewHeight / (float)(maxMidi - minMidi);
		float middleMidi = 0.5f * (float)(maxMidi + minMidi);
		
		return dy * (midiVal - middleMidi);

	}

	// scroll game object to left so that new pitch values are drawn on the same position of the screen
	private void MoveLeft(float amount) {
		var tmp = transform.position;
		tmp.x -= amount;
		transform.position = tmp;
	}
}