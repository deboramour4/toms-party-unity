using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript2OLD : MonoBehaviour {

	public GameObject progressBar;

	public GameObject[] objPhotos = new GameObject[3];
	private PlayingNote2[] photos = new PlayingNote2[3];
	public int[] photosID = new int[3];
	public AudioClip[] sounds = new AudioClip[2];


	private bool isPlayable;
	private bool valido;
	public bool Rounding;
	private bool isCorrect;
	private Animator animProgress;



	// Use this for initialization
	void Start () {
		for (int i = 0; i < 3; i++) {
			photos[i] = objPhotos[i].GetComponent<PlayingNote2>();
		}

		animProgress = progressBar.GetComponent <Animator>();
		//cont = 0;

		valido = false;
		isPlayable = false;

		//isCorrect = false;

		//accessing the bugle's scripts

		SoundsOrder ();
		StartCoroutine ("Round");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Round(){
		yield return new WaitForSeconds (1f);
		photos[0].Play ();
		yield return new WaitForSeconds (2f);
		photos[1].Play ();
		yield return new WaitForSeconds (2f);
		photos[2].Play ();
		//isPlayable = true;
	}

	void RandomOrder(int[] b){
		for (int i = 0; i < b.Length; i++) {
			photosID[i] = Random.Range(0,2);
		}
		Debug.Log (photosID[0]+", "+photosID[1]+", "+photosID[2]);
	}

	void SoundsOrder(){

		RandomOrder(photosID);
		Debug.Log (photosID[0] +", "+photosID[1]);
		for(int i = 0; i<photosID.Length; i++){
			//Debug.Log ("FOR");
			switch(photosID[i]){
			case 0:					
				photos [i].setId (0);					
				photos [i].setNote (sounds [0]);
				isCorrect = photos [i].getCorrect();
				Debug.Log ("Case 0 (DO): "+photos [i].getId());
				break;
			case 1:				
				photos [i].setId(1);					
				photos [i].setNote(sounds [1]);
				Debug.Log ("Case 1(NÃO): "+photos [i].getId());
				break;
			}
		}
	}

	public bool getIsPlayable(){
		return this.isPlayable;
	}

	public void setIsPlayable(bool isPlayable){
		this.isPlayable = isPlayable;
	}
}
