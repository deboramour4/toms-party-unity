using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingNote : MonoBehaviour {
	
	public AudioSource note;
	public int id;

	//Play the audio source;
	public void Play(){
		note.Play();
	}

	public void Check(){
		if (id == 0) {
			Debug.Log ("ACERTÔ MISERAVI");
		} else {
			Debug.Log ("EROOOOOU");
		}
	}
}
