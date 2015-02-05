using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// USE THIS SCRIPT ON THE PLAYER. REMEMBER TO NAME THE STARS.
	//COUNTER IS NOT IMPLEMENTED YET. THAT COMES WITH SCORE SYSTEM?

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Star1" || other.gameObject.name == "Star2" || other.gameObject.name == "Star3") {

						Destroy (other.gameObject);
				}
	}
}
