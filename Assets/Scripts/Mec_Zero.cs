using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mec_Zero : MonoBehaviour {

	//gameObject
	public GameObject objPlayer; //player
	public GameObject progressBar; //progressBar
	public GameObject victory;


	//audios
	//player
	private AudioSource playerAudioSource;

	//collisor
	Collider2D playerCollider;

	//animation
	Animator playerAnimator;
	Animator pBarAnimator;
	public float secToSing;

	//mechanic
	public static int stars;

	void Start () {
		//Elements of the player
		playerCollider = objPlayer.GetComponent<BoxCollider2D> ();
		playerAnimator = objPlayer.GetComponent<Animator>();
		playerAudioSource = objPlayer.GetComponent<AudioSource> ();

		//Elements of the progress bar
		pBarAnimator = progressBar.GetComponent<Animator>();

		//about the mechanic
		stars = 0;
	}


	void Update () {
		//Make player sing
		if(Input.GetMouseButtonDown(0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (playerCollider.OverlapPoint (mousePosition)) {
				//make sing: change animation, play note
				playerAnimator.SetTrigger("sing");
				stars++;
				StartCoroutine ("sing");
			}
		}

		//end the level
		if (stars >= 5 ){
			StartCoroutine("theEnd");
		}
	}
		
	//victory screen
	IEnumerator theEnd () {
		yield return new WaitForSeconds (2f);
		victory.SetActive (true);
	}

	IEnumerator sing(){
		yield return new WaitForSeconds(1f);
		pBarAnimator.SetInteger("cont",stars);
		playerAudioSource.Play ();
		StartCoroutine("stoSing");
	}

	IEnumerator stopSing(){
		yield return new WaitForSeconds (secToSing);
		playerAnimator.SetTrigger("idle");
	}
}