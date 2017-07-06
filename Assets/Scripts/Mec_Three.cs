using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mec_Three : MonoBehaviour {

	//gameObject
	public GameObject objPlayer; //player
	public GameObject[] objWood = new GameObject[4]; //woods
	public GameObject progressBar; //progressBar


	//audios
	//player
	private AudioSource playerAudioSource;
	public AudioClip[] sounds = new AudioClip[2];
	//woods
	private AudioSource[] woodAudioSource = new AudioSource[4];

	//id  woods
	int[] woodsOrder = new int[4]; 

	//collisor
	Collider2D playerCollider;

	//animation
	Animator playerAnimator;
	Animator[] woodAnimator = new Animator[4];
	Animator pBarAnimator;


	void Start () {
		//Elements of the player
		playerCollider = objPlayer.GetComponent<BoxCollider2D> ();
		playerAnimator = objPlayer.GetComponent<Animator>();
		playerAudioSource = objPlayer.GetComponent<AudioSource> ();

		//Elements of the woods
		for (int i = 0; i < 4; i++) {
			woodAudioSource[i] = objWood [i].GetComponent<AudioSource>();
			woodAnimator[i] = objWood [i].GetComponent<Animator> ();
		}

		//Elements of the progress bar
		pBarAnimator = progressBar.GetComponent<Animator>();

		chooseWoodsNotes ();
	}

	void FixedUpdate () {
		//Debug.Log ("position player= "+playerTransform.position.x+" | posX= "+posX);

		/*if (isSinging) {
			playerAnimator.CrossFade ("sing", 0f); //change the animation immediately
		} else if (isWalking) {
			playerAnimator.CrossFade ("walking", 0f);
			//go up
			if (up && posX > playerTransform.position.x) {
				playerTransform.Translate (1f* Time.deltaTime, 1.2f * Time.deltaTime, 0.0f);
			} else if (up) {
				isWalking = false;
				getTime = true;
			}

			//go down
			if (down && posX > playerTransform.position.x) {
				playerTransform.Translate (1f* Time.deltaTime, -1.2f * Time.deltaTime, 0.0f);
			} else if (down) {
				isWalking = false;
				getTime = true;
			}
				
		} else {
			playerAnimator.CrossFade ("idle", 0f);
		}*/


	}
		
	void Update () {
		
		/*//Debug.Log ("Walk: "+isWalking);
		//Make player sing
		if(Input.GetMouseButtonDown(0)) {

			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (playerCollider.OverlapPoint (mousePosition) && !isSinging && !isWalking) {
				//save the time of the click
				if (getTime) {
					time = Time.frameCount;
					posX = playerTransform.position.x+1.7f;
					getTime = false;
				}

				//make sing: change animation, play note
				isSinging = true;
				playerAudioSource.Play ();
			}
		}

		//make the player walk after a time
		if (isSinging && !isWalking && Time.frameCount > time + 70 && col<8) {
				isSinging = false;
				isWalking = true;
				time = Time.frameCount;
		}

		//make the player stop walk after a time
		if (isWalking && Time.frameCount > time + 50 && col<9) {
			isWalking = false;
			getTime = true;
		}*/
			
	}


	void chooseWoodsNotes() {
		bool valido;
		for (int i = 0; i < 4; i++) {
			do {
				woodsOrder [i] = Random.Range (0, 4);
				;
				valido = true;
				for (int j = 0; j < i; j++)
					if (woodsOrder [i] == woodsOrder [j])
						valido = false;
			} while (valido == false);
		}	
		Debug.Log("note1="+woodsOrder[0]+"  note2="+woodsOrder[1]+"  note3="+woodsOrder[2]+"  note4="+woodsOrder[3]);
		setWoodsNotes ();
	}
		
	void setWoodsNotes(){
		woodAudioSource[woodsOrder[0]].clip = sounds [0];
		woodAudioSource[woodsOrder[1]].clip = sounds [0];
		woodAudioSource[woodsOrder[2]].clip = sounds [1];
		woodAudioSource[woodsOrder[3]].clip = sounds [1];
	}
}