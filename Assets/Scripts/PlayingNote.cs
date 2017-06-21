using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingNote : MonoBehaviour {
	
	private AudioSource note;
	private int id;

	void Start(){
		note = GetComponent<AudioSource> ();
	}

	public void checkNote(){
		//play the note
		note.Play();

		//check if is the correct note
		if (id == 0) {
			Debug.Log ("ACERTÔ MISERAVI");
		} else {
			Debug.Log ("EROOOOOU");
		}
	}

	public void Play(){
		//play the note
		note.Play();
	}

	public void setNote(AudioClip clip){
		this.note.clip = clip;
	}
	public void setId(int id){
		this.id = id;
	}
	public int getId(){
		return this.id;
	}
}
