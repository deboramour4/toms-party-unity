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

	void OnCollisionEnter2D(Collision2D other){
		Debug.Log ("aeeee");
		if(other.gameObject.tag == "PhotoDo"){
			
			portraitDo.SetActive (true);
			spriteDo.sortingOrder = 1;
			spriteRe.sortingOrder = 0;
		}
	}

}
