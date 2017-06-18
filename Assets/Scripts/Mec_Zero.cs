using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mec_Zero : MonoBehaviour {

	//audio
	public AudioSource audioSource;

	//moviment
	private Transform tPlayer;
	private bool isWalking;
	private bool isSinging;
	private float time;
	private bool getTime;
	private float count;


	//collisor
	Collider2D objCollider;

	//animation
	Animator animator;

	void Start () {
		objCollider = GetComponent<PolygonCollider2D> ();
		animator = GetComponent<Animator>();
		tPlayer = GetComponent<Transform>();
		isWalking = false;
		isSinging = false;
		getTime = true;
		time = 0;
		count = 0;
	}

	void FixedUpdate () {
		if (isSinging) {
			animator.CrossFade ("sing", 0f); //change the animation immediately
		} else if (isWalking) {
			animator.CrossFade ("walking", 0f);
			tPlayer.Translate(1f * Time.deltaTime,  0.0f, 0.0f );
		} else {
			animator.CrossFade ("idle", 0f);
		}
	}
		
	void Update () {
		if(Input.GetMouseButtonDown(0)) {

			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (objCollider.OverlapPoint (mousePosition) && transform.position.x > -3.5 && transform.position.x < 3.5) {
				//save the time of the click
				if (getTime) {
					time = Time.frameCount;
					getTime = false;
					Debug.Log (time);
					Debug.Log (Time.frameCount);
				}

				//make sing: change animation, play note
				isSinging = true;
				audioSource.Play ();

				//increments the count (max: 5)
				count++;
			}			
		}

		//make the player walk after a time
		if (isSinging && !isWalking && Time.frameCount > time + 70 && count<=5) {
				isSinging = false;
				isWalking = true;
				time = Time.frameCount;
		}

		//make the player stop walk after a time
		if (isWalking && Time.frameCount > time + 90 && count<=5) {
			isWalking = false;
			getTime = true;
		}
			
	}

	void restart(){
		isWalking = false;
		isSinging = false;
		getTime = true;
		time = 0;
		count = 0;
	}
}