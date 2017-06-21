using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour {

	public GameObject objPlayer; 
	public GameObject[] objBugles = new GameObject[3];
	public PlayingNote[] bugles = new PlayingNote[3];
	public AudioClip[] sounds = new AudioClip[3];

	private bool isPlayable;
	private bool valido;
	public bool Rounding;

	public int[] buglesID = new int[3];


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 3; i++) {
			bugles [i] = objBugles[i].GetComponent<PlayingNote>();
		}

		//isPlayable = objPlayer.GetComponent<PlayerStates>().isPlayable2;
		valido = false;

		//accessing the bugle's scripts
		SoundsOrder ();
		StartCoroutine ("Waiting");

	}

	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0)){
			Debug.Log (buglesID[0]+", "+buglesID[1]+", "+buglesID[2]);
		}
			
	}

	//Wainting to start the sounds
	IEnumerator Waiting(){
		yield return new WaitForSeconds (2.5f);
		StartCoroutine ("Round");
	}


	//Playing the three sounds
	IEnumerator Round(){
		yield return new WaitForSeconds (1f);
		bugles[0].Play ();
		yield return new WaitForSeconds (2f);
		bugles[1].Play ();
		yield return new WaitForSeconds (2f);
		bugles[2].Play ();

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
		Debug.Log (buglesID[0]+", "+buglesID[1]+", "+buglesID[2]);
		for(int i = 0; i<buglesID.Length; i++){
			switch(buglesID[i]){
			case 0:
				bugles [i].setId(0);
				bugles [i].setNote(sounds [0]);
				Debug.Log ("1: "+bugles [i].getId());
				break;
			case 1:
				bugles [i].setId(1);
				bugles [i].setNote(sounds [1]);
				Debug.Log ("2: "+bugles [i].getId());
				break;
			case 2:
				bugles [i].setId(2);
				bugles [i].setNote(sounds [2]);
				Debug.Log ("3: "+bugles [i].getId());
				break;
			}
		}
	}
}