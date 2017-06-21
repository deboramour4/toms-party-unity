using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour {

	public float speed;
	public AudioSource note;

	private Transform tPlayer;
	private Animator animator;
	private bool isWalking;
	private bool isSinging;
	private bool isHappy;
	private float destination;
	//private PlayAutomatically managerScript;
	public bool isPlayable2;

	Collider2D objCollider;

	// Use this for initialization
	void Start () {
		tPlayer = GetComponent<Transform>();
		animator = GetComponent<Animator>();
		objCollider = GetComponent<Collider2D>();

		isPlayable2 = false;
		isWalking = false;
		isHappy = false;
		isSinging = false;
	}
		
	void FixedUpdate () {
		Move(0.0f);
		Sing ();

		if (note.isPlaying) {
			animator.CrossFade ("sing", 0f); //change the animation immediately
		} else if (isWalking) {
			animator.CrossFade ("walking", 0f);
			tPlayer.Translate(1f * Time.deltaTime,  0.0f, 0.0f );
		} else if (isHappy) {
			animator.CrossFade ("happy", 0f);
		} else {
			animator.CrossFade ("idle", 0f);
		}
	}

	void Move(float destination){
		if(transform.position.x<destination){
			tPlayer.Translate(speed * Time.deltaTime , 0.0f, 0.0f);
			isWalking = true;
		}else{
			isPlayable2 = true;
			isWalking = false;
		}
	}

	void Sing(){
		if(Input.GetMouseButtonDown(0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if(objCollider.OverlapPoint(mousePosition)) {
				isSinging = true;
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
