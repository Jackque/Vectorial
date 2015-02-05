using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathWallBehavior : MonoBehaviour {
	public Image ImageToFade;//GAME OVER SCREEN IMAGE
	public float fadeSpeed;//Rate of fade, use values 1 to 10 pref
	public GameObject testForCollision;//object that collision tests for
	
	private bool BeginFade = false;//something to trigger the fade effect in update.
	
	
	public void OnCollisionEnter(Collision obj){//When something collides
		if (obj.gameObject == testForCollision) {//If collision is gameobject specified in editor
			BeginFade = true;//allow fade effect in update
		}
	}
	
	
	public void Update(){//this runs per frame
		if (BeginFade && ImageToFade.color.a <= 1) {
			Color tmpColor = ImageToFade.color;//tmp variable because you cannot directly access this property
			tmpColor.a = tmpColor.a + (fadeSpeed/100);//fade effect
			ImageToFade.color = tmpColor;
		}
		if (Input.GetKeyDown(KeyCode.R)) {//RESET CODE==========REMOVE BEFORE FINAL BUILD
			BeginFade = false;
			Color tmpColor = ImageToFade.color;
			tmpColor.a = 0;
			ImageToFade.color = tmpColor;
		}//END OF RESET CODE==================REMOVE BEFORE FINAL BUILD
	}
}
