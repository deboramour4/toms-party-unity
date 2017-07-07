using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
	Vector3 dist;
	float posX;
	float posY;
	SpriteRenderer sprite;
	SpriteRenderer other;

	public GameObject otherPhoto;

	void Start(){
		sprite = GetComponent<SpriteRenderer> ();
		other = otherPhoto.GetComponent<SpriteRenderer> ();
	}

	void OnMouseDown(){
		dist = Camera.main.WorldToScreenPoint (transform.position);
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
	
		sprite.sortingOrder = 1;
		other.sortingOrder = 0;
	}

	void OnMouseDrag(){
		Vector3 mousePos = new Vector3 (Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);

		Vector3 worldPos = Camera.main.ScreenToWorldPoint (mousePos);
		transform.position = worldPos;

	}
}
