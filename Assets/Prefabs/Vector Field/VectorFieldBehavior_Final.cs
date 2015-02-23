using UnityEngine;
using System.Collections;

/*Writer: Luke Jones
 * ATTACH TO: Vector Field Prefab
 * 
 * Objects referenced:
 *   > fieldMagnitude: magnitude of the vector that this GameObject applies
 *   > affectedObjects: objects that will be affected by this GameObject
 * 
 * Commments: This version is very simple and elegent. There were two previous methods of application built and tested
 * but none worked as nicely as desired. Since the design change to decimal, this solution is the most simple. (aka this wasn't all i did)*/


public class VectorFieldBehavior_Final : MonoBehaviour {
	public Vector3 fieldMagnitude;//the magnitude of the field reccomended 0 - 1 values (i.e. 0.2)
	public GameObject[] affectedObjects; // please attach the objects to be affected by the field

	private bool[] objectAffected;// Keeps track of which affected objects are in the field

	void Start(){
		objectAffected = new bool[affectedObjects.Length];
	}
	//Where collisions are checked and turned on
	void OnTriggerEnter(Collider col){
		int i;
		for (i=0; i<affectedObjects.Length; i++){//checks each object in affectedObjects, and will update objectAffected to show it's in the field
			if (col.gameObject == affectedObjects[i]) {
				objectAffected[i] = true;
			}
		}
	}

	//Where the collisons are checked and turned off
	void OnTriggerExit(Collider col){
		int i;
		for (i=0; i<affectedObjects.Length; i++){//checks each object in affectedObjects, and will update objectAffected to show it's no longer in the field
			if (col.gameObject == affectedObjects[i]) {
				objectAffected[i] = false;
			}
		}
	}
	
	//Where the force is applied
	void Update () {
		int i;
		for (i=0; i<affectedObjects.Length; i++){//checks the status of each object, and if it's in the field add the vector force
			if (objectAffected[i]) {
				float tmpz = affectedObjects[i].rigidbody.velocity.z + fieldMagnitude.z;//z value that will be after next update
				float tmpx = affectedObjects[i].rigidbody.velocity.x + fieldMagnitude.x;//x value
				if(tmpz <= 25 && tmpz >= -25 && tmpx <= 25 && tmpx >= -25){//make sure we dont go too fast
					affectedObjects[i].rigidbody.AddForce(fieldMagnitude,ForceMode.VelocityChange);//force is added
				}
			}
		}
	}
}
