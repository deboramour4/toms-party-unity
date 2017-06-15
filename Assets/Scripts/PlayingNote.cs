using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingNote : MonoBehaviour {
	
	public AudioSource note;

	//Play the audio source;
	public void Play(){
		note.Play();
	}
}
