using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour {

	public float speed;
	public AudioSource note;

	private Transform tPlayer;
	private Animator animPlayer;
	private bool isWalking;
	private bool isSinging;
	private float destination;

	Collider2D objCollider;

	// Use this for initialization
	void Start () {
		tPlayer = GetComponent<Transform>();
		animPlayer = GetComponent<Animator>();
		objCollider = GetComponent<Collider2D> ();
		isWalking = false;
		isSinging = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		Move(0.0f);
		Sing ();

		animPlayer.SetBool ("isWalking",isWalking);
		animPlayer.SetBool ("isSinging",note.isPlaying);
	}

	void Move(float destination){
		//if(Input.GetMouseButtonDown(0)){
		//	isWalking = true;
		//}

		if(transform.position.x<destination){
			tPlayer.Translate(speed * Time.deltaTime , 0.0f, 0.0f);
			isWalking = true;
		}else{
			destination += 3.0f;
			isWalking = false;
		}

		//animPlayer.SetBool ("isWalking",isWalking);

		Debug.Log(isWalking);
		Debug.Log(destination);
	}

	void Sing(){
		if(Input.GetMouseButtonDown(0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if(objCollider.OverlapPoint(mousePosition)) {
				isSinging = true;
				//isWalking = true;
				Debug.Log(isSinging);
			}
		}

		if (isSinging){
			note.Play();
			isSinging = false;
		}	
	}
}
