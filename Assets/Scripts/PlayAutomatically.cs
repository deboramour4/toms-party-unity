using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAutomatically : MonoBehaviour {
	
	public GameObject bugle1;
	public GameObject bugle2;
	public GameObject bugle3;

	private PlayingNote b1Script;
	private PlayingNote b2Script;
	private PlayingNote b3Script;

	// Use this for initialization
	void Start () {
		//accessing the bugle's scripts
		b1Script = bugle1.GetComponent<PlayingNote> ();
		b2Script = bugle2.GetComponent<PlayingNote> ();
		b3Script = bugle3.GetComponent<PlayingNote> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			StartCoroutine ("Round");
		}
	}

	IEnumerator Round(){
		yield return new WaitForSeconds (1f);
		b1Script.Play ();
		yield return new WaitForSeconds (2f);
		b2Script.Play ();
		yield return new WaitForSeconds (2f);
		b3Script.Play ();
	}

	void RandomOrder(){
		
	}
}
