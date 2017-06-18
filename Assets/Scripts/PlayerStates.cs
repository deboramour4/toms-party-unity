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
	//private PlayAutomatically managerScript;
	public bool isPlayable2;

	Collider2D objCollider;

	// Use this for initialization
	void Start () {
		tPlayer = GetComponent<Transform>();
		animPlayer = GetComponent<Animator>();
		objCollider = GetComponent<Collider2D>();

		isPlayable2 = false;
		isWalking = false;
		isSinging = false;
	}
		
	void FixedUpdate () {
		Move(0.0f);
		Sing ();

		animPlayer.SetBool ("isWalking",isWalking);
		animPlayer.SetBool ("isSinging",note.isPlaying);
	}

	void Move(float destination){

		if(transform.position.x<destination){
			tPlayer.Translate(speed * Time.deltaTime , 0.0f, 0.0f);
			isWalking = true;
		}else{
			isPlayable2 = true;
			isWalking = false;

		}

		//Debug.Log(isWalking);
		//Debug.Log(destination);
	}

	void Sing(){
		if(Input.GetMouseButtonDown(0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if(objCollider.OverlapPoint(mousePosition)) {
				isSinging = true;
				//Debug.Log(isSinging);
			}
		}

		if (isSinging){
			StartCoroutine("SingDelay");
		}	
	}

	IEnumerator SingDelay(){
		yield return new WaitForSeconds (0.5f);
		note.Play();
		isSinging = false;
	}

}
