using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchShifter : MonoBehaviour {

	AudioSource myAudio;
	// Use this for initialization
	void Start () {
		myAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayEatSound(){
		myAudio.pitch = Random.Range(0.75f, 1.1f);
		if(!myAudio.isPlaying){
 			myAudio.PlayScheduled(AudioSettings.dspTime + .00001f);
		}
	}
}
