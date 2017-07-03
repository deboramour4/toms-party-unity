using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript2 : MonoBehaviour {

	public GameObject progressBar;

	public GameObject[] objPhotos = new GameObject[3];
	private PlayingNote2[] photos = new PlayingNote2[3];
	public int[] photosID = new int[3];
	public AudioClip[] sounds = new AudioClip[3];

	// Use this for initialization
	void Start () {
		
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
}
