using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour {

	public GameObject objPlayer; 
	public GameObject[] bugles = new GameObject[3];
	public GameObject[] notes = new GameObject[3];
	public AudioClip[] sounds = new AudioClip[3];

	private PlayingNote b1Script;
	private PlayingNote b2Script;
	private PlayingNote b3Script;

	private bool isPlayable;
	private bool valido;
	public bool Rounding;

	public int[] buglesID = new int[3];


	// Use this for initialization
	void Start () {
		//isPlayable = objPlayer.GetComponent<PlayerStates>().isPlayable2;
		valido = false;

		b1Script = bugles[0].GetComponent<PlayingNote>();
		b2Script = bugles[1].GetComponent<PlayingNote>();
		b3Script = bugles[2].GetComponent<PlayingNote>();
		//accessing the bugle's scripts
		SoundsOrder ();
		StartCoroutine ("Waiting");

	}

	void FixedUpdate () {
		//Debug.Log ("variavel = "+isPlayable);
		if(Input.GetMouseButtonDown(0)){
			Debug.Log (buglesID[0]+", "+buglesID[1]+", "+buglesID[2]);
		}
	}

	//Wainting to start the sounds
	IEnumerator Waiting(){
		yield return new WaitForSeconds (3.5f);
		StartCoroutine ("Round");
	}


	//Playing the three sounds
	IEnumerator Round(){
		yield return new WaitForSeconds (1f);
		b1Script.Play ();
		yield return new WaitForSeconds (2f);
		b2Script.Play ();
		yield return new WaitForSeconds (2f);
		b3Script.Play ();

	}

	void RandomOrder(int[] b){
		for (int i = 0; i < b.Length; i++) {
			do {
				buglesID[i] = Random.Range(0,3);
				valido = true;
				for (int j = 0; j < i; j++)
					if (b[i] == buglesID[j])
						valido = false;
			} while (valido == false);
		}
	}

	void SoundsOrder(){
		RandomOrder(buglesID);
		for(int i = 0; i<buglesID.Length; i++){
			switch(buglesID[i]){
			case 0:
				notes [i].GetComponent<AudioSource> ().clip = sounds [0];
				bugles [i].GetComponent<PlayingNote> ().id = 0;
				break;
			case 1:
				notes [i].GetComponent<AudioSource>().clip = sounds[1];
				bugles [i].GetComponent<PlayingNote> ().id = 1;
				break;
			case 2:
				notes [i].GetComponent<AudioSource>().clip = sounds[2];
				bugles [i].GetComponent<PlayingNote> ().id = 2;
				break;
			}
		}
	}
}