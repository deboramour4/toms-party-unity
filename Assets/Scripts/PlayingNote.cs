using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingNote : MonoBehaviour {

	public GameObject player;

	
	private AudioSource note;
	private int id;
	private PlayerStates script;

	void Start(){
		note = GetComponent<AudioSource> ();
		script = player.GetComponent<PlayerStates> ();
	}

	public void checkNote(){
		//play the note
		note.Play();

		//check if is the correct note
		if (id == 0) {
			script.setIsHappy (true); 
			Debug.Log ("ACERTÔ MISERAVI");
		} else {
			script.setIsSad (true);
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
