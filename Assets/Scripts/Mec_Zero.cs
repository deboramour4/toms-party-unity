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
	private float sliceOfTime;


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
		time = 0;
	}
		
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if(objCollider.OverlapPoint(mousePosition)) {
				isSinging = true;
				sliceOfTime = time;
				//isWalking = true;
				Debug.Log(sliceOfTime);
				Debug.Log(isSinging);

			}
		}

		if (isSinging){
			audioSource.Play();
			animator.CrossFade ("sing", 0f);
			isSinging = false;
		}

		if(isSinging && time > sliceOfTime+80)
				isWalking = true;

		if(isWalking){
			animator.CrossFade ("walking",0f);
			tPlayer.Translate(1.5f * Time.deltaTime,  0.0f, 0.0f );
			//Debug.Log(1f * Time.deltaTime);
		}

		time++;
		//Debug.Log(time);




			//Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			//if(objCollider.OverlapPoint(mousePosition) && transform.position.x>-3.5 && transform.position.x<3.5) {
				//animator.CrossFade ("sing",0f); //change the animation immediately
				/*if(transform.position.x <= transform.position.x+1.4f){*/
					
					//tPlayer.Translate(1f * Time.deltaTime,  0.0f, 0.0f );

					//animator.CrossFade ("walking",0f);
				/*}*/
				//setX (transform.position.x+1.4f);
				//audioSource.Play();
				 //animator.CrossFade ("idle", 0.3f);
			//}
		
		
	}

	void setX(float n){
		transform.position = new Vector3(n, transform.position.y, transform.position.z);
	}

	void setY(float n){
		transform.position = new Vector3 (transform.position.x, n, transform.position.z);
	}
		
}