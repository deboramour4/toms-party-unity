using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

	public GameObject portraitDo;
	public GameObject portraitRe;

	SpriteRenderer spriteDo;
	SpriteRenderer spriteRe;

	void Start(){
		spriteDo = portraitDo.GetComponent<SpriteRenderer> ();
		spriteRe = portraitRe.GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("aeeee");
		if(other.gameObject.tag == "PhotoDo"){
			portraitDo.SetActive (true);
			spriteDo.sortingOrder = 1;
			spriteRe.sortingOrder = 0;
		} else if(other.gameObject.tag == "PhotoRe"){
			portraitRe.SetActive (true);
			spriteDo.sortingOrder = 0;
			spriteRe.sortingOrder = 1;
		}
	}

}
