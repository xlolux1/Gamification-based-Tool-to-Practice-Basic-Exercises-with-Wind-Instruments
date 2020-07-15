using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.IO;
using System.Linq;
using PitchDetector;

public class Demo : MonoBehaviour
{
public void LogPitch (List<float> pitchList, int samples, float db) {
    var midis = RAPTPitchDetectorExtensions.HerzToMidi (pitchList);
Debug.Log ("detected " + pitchList.Count + " values from " + samples
+ " samples, db:" + db);
Debug.Log (midis.NoteString ());
}
}
