using UnityEngine;
using System.Collections;

public class VectorBuildPanel : MonoBehaviour {
	public Animator animator;

	public void setBool(bool x){
		animator.SetBool ("IsOpen", x);
	}
}
