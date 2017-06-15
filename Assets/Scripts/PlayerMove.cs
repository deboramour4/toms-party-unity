using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float speed;

	private Transform tPlayer;
	private Animator animPlayer;
	private bool moving;
	private float destination;

	// Use this for initialization
	void Start () {
		tPlayer = GetComponent<Transform>();
		animPlayer = GetComponent<Animator>();
		moving = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		Move(0.0f);
	}


	void Move(float destination){
		//if(Input.GetMouseButtonDown(0)){
		//	moving = true;
		//}

		if(transform.position.x<destination){
			tPlayer.Translate(speed * Time.deltaTime , 0.0f, 0.0f);
			moving = true;
		}else{
			destination += 3.0f;
			moving = false;
		}

		animPlayer.SetBool ("moving",moving);

		Debug.Log(moving);
	}
}
