using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mec_Two : MonoBehaviour {

	//gameObject
	public GameObject objPlayer;
	public GameObject[] objFlower = new GameObject[3];

	//audio
	private AudioSource playerAudioSource;
	public AudioClip[] sounds = new AudioClip[3];

	//playnotes
	private PlayingNote[] flowers = new PlayingNote[3];

	public int[] flowersID = new int[3];
	private bool valido;

	//moviment
	private Transform playerTransform;
	private bool isWalking;
	private bool isSinging;
	private float time;
	private bool getTime;
	private float col;
	private bool up, down;

	//random 
	//collisor
	Collider2D playerCollider;

	//animation
	Animator playerAnimator;
	Animator[] flowerAnimator = new Animator[3];

	//end
	private bool win;
	private float posX;

	/*//save the time of the click
	if (getTime) {
		time = Time.frameCount;
		getTime = false;
	}*/

	void Start () {
		//Elements of the player
		playerCollider = objPlayer.GetComponent<BoxCollider2D> ();
		playerAnimator = objPlayer.GetComponent<Animator>();
		playerTransform = objPlayer.GetComponent<Transform>();
		playerAudioSource = objPlayer.GetComponent<AudioSource> ();

		//Elements of the flowers
		for (int i = 0; i < 3; i++) {
			flowers [i] = objFlower[i].GetComponent<PlayingNote>();
			flowers [i].setAnimator (objFlower [i].GetComponent<Animator> ());
		}
			
		valido = false;
		isWalking = false;
		isSinging = false;
		getTime = true; // able or disable the possibility to get the current frame(time)
		time = 0; // the variable that gets the current frame(time)
		posX = playerTransform.position.x;
		down = true;
		up = false;
		win = false;

		chooseFlowerNotes ();

		//WHEN THE TUTORIAL ENDS
		Debug.Log(flowers [0].getAnimator());
		//Debug.Log(objFlower [1].GetComponent<Animator> ());
		objFlower [1].SetActive (false);
		objFlower [2].SetActive (false);
	}

	void FixedUpdate () {
		//Debug.Log ("position player= "+playerTransform.position.x+" | posX= "+posX);

		if (isSinging) {
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
		}


	}
		
	void Update () {
		
		//Debug.Log ("Walk: "+isWalking);
		//Make player sing
		if(Input.GetMouseButtonDown(0)) {

			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (playerCollider.OverlapPoint (mousePosition) && !isSinging && !isWalking) {
				if (down) {
					up = true;
					down = false;
				} else if (up) {
					down = true;
					up = false;
				}
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

		/*//make the player stop walk after a time
		if (isWalking && Time.frameCount > time + 50 && col<9) {
			isWalking = false;
			getTime = true;
		}*/
			
	}

	void clickFlower(int id){
		if (id == 0) {
			flowers [0].Play ();
			col++; // next col
			isWalking = true;
			//player.moveAnywhere(posX[a], posY[0], 2);
		}  
		if (id == 1) { 
			flowers [1].Play ();
			//sTry.playSound(); tente de novo
		}
		if (id == 2) {
			flowers [2].Play ();
			//sTry.playSound(); tente de novo
		} else if (col >6) {
			win = true;
			congrats();
		}

	}

	void chooseFlowerNotes() {
		for (int i = 0; i <3; i++) {
			do {
				flowersID[i] = Random.Range(0,3);;
				valido = true;
				for (int j = 0; j < i; j++)
					if (flowersID[i] == flowersID[j])
						valido = false;
			} while (valido == false);
		}
		setFlowerNotes ();
	}

	void setFlowerNotes(){

		// set audiosource clips notes for flowers
		for(int i =0; i<3; i++){
			flowers [i].setId (flowersID [i]);
			//flowers [i].setNote (sounds [flowersID [i]]);
			Debug.Log (sounds [flowers[i].getId ()]);
		}
	}

	void restart(){
		isWalking = false;
		isSinging = false;
		getTime = true;
		time = 0;
		col = 0;
	}

	void congrats(){
		Debug.Log ("GANHOU");
	}

}