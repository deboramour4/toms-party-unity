using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mec_Zero : MonoBehaviour {

	//adio
	public AudioSource audioSource;

	//moving
	private int screenW;
	private float screenSlice;
	private int count;

	//collisor
	Collider2D objCollider;

	//animation
	Animator animator;

	void Start () {
		objCollider = GetComponent<PolygonCollider2D> ();
		animator = GetComponent<Animator>();

		screenW = Screen.width;
		screenSlice = (screenW - 250) / 5;
		Debug.Log ("Largura da tela" + screenW);

		Debug.Log ("teoricamente a largura da tela"+transform.position.x);


	}
		
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if(objCollider.OverlapPoint(mousePosition) && transform.position.x>-3.5 && transform.position.x<3.5) {
				animator.SetTrigger ("walk");
				setX (transform.position.x+1.4f);
				audioSource.Play();
			}
		}
	}

	void setX(float n){
		transform.position = new Vector3(n, transform.position.y, transform.position.z);
	}

	void setY(float n){
		transform.position = new Vector3 (transform.position.x, n, transform.position.z);
	}
		
}
