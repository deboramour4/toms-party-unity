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

	//singing
	bool isSinging;
	bool getTime;
	float time;


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

		//animation singing
		isSinging = false;
		chooseWoodsNotes ();
	}

	void FixedUpdate () {
		if (isSinging) {
			playerAnimator.CrossFade ("sing", 0f); //change the animation immediately
		} else {
			playerAnimator.CrossFade ("idle", 0f);
		}
			
	}
		
	void Update () {
		//Make player sing
		if(Input.GetMouseButtonDown(0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (playerCollider.OverlapPoint (mousePosition)) {
				if (getTime) {
					time = Time.frameCount;
					getTime = false;
				}

				//make sing: change animation, play note
				isSinging = true;
				playerAudioSource.Play ();
			}
		}
						
		//make the player stop singing after a time
		if (isSinging && Time.frameCount > time + 170) {
			isSinging = false;
			getTime = true;
		}			
			
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

	public void clickWood(int wood){
		woodAnimator [wood].SetTrigger ("show");
		Debug.Log(woodAudioSource [wood].clip);
		woodAudioSource [wood].Play ();
	}
}