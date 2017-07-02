using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript2 : MonoBehaviour {

	public GameObject objPlayer; 
	public GameObject progressBar;

	public GameObject[] objPhotos = new GameObject[3];
	private PlayingNote[] photos = new PlayingNote[3];
	public int[] photosID = new int[3];
	public AudioClip[] sounds = new AudioClip[3];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
