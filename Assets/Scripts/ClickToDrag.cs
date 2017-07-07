using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDrag : MonoBehaviour {
	
	SpriteRenderer sprite;
	SpriteRenderer otherSprite;
	SpriteRenderer draggable;

	public GameObject otherPhoto;
	public GameObject draggablePhoto; 

	void Start(){
		sprite = GetComponent<SpriteRenderer> ();
		otherSprite = otherPhoto.GetComponent<SpriteRenderer> ();
		draggable = draggablePhoto.GetComponent<SpriteRenderer> ();
	}

	void OnMouseDown(){
		sprite.sortingOrder = 1;
		otherSprite.sortingOrder = 0;
		if (draggablePhoto.activeInHierarchy == false) {
			draggablePhoto.SetActive (true);
		}
	}
}
