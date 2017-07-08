using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

	Vector3 temp;      //temporary variable to transform
	Vector3 dist;	   
	float posX;
	float posY;
	float initPosX;    //initial position of X;
	float initPosY;    //initial position of X;
	bool isDragging;

	//Photos objects
	public GameObject otherPhoto;
	public GameObject staticPhoto1;
	public GameObject staticPhoto2;

	//Photos Sprites
	SpriteRenderer sprite;
	SpriteRenderer otherSprite;
	SpriteRenderer staticSprite1;
	SpriteRenderer staticSprite2;

	void Start(){
		temp = transform.position;
		initPosX = temp.x;
		initPosY = temp.y;
		sprite = GetComponent<SpriteRenderer> ();
		otherSprite = otherPhoto.GetComponent<SpriteRenderer> ();
		staticSprite1 = staticPhoto1.GetComponent<SpriteRenderer> ();
		staticSprite2 = staticPhoto2.GetComponent<SpriteRenderer> ();
		isDragging = false;
	}

	//While is dragging
	void OnMouseDown(){
		dist = Camera.main.WorldToScreenPoint (transform.position);
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
	
		sprite.sortingOrder = 1;
		otherSprite.sortingOrder = 0;
		staticSprite1.sortingOrder = 1;
		staticSprite2.sortingOrder = 0;

		isDragging = true;
	}

	void OnMouseDrag(){
		Vector3 mousePos = new Vector3 (Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);

		Vector3 worldPos = Camera.main.ScreenToWorldPoint (mousePos);
		transform.position = worldPos;

	}

	void OnMouseUp(){
		temp.x = initPosX;
		temp.y = initPosY;
		transform.position = temp;
		isDragging = true;
	}

	void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("aeeee");
	}


	bool getIsDragging(){
		return isDragging;
	}
}
