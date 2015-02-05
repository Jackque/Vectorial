using UnityEngine;
using System.Collections;

public class UIPlayerController : MonoBehaviour {
	public float speed; // can change speed per key press, editable in unity ui
	//preset directional vectors for use in Move Commands
	private Vector3 upDir = new Vector3(0,0,1);
	private Vector3 downDir = new Vector3(0,0,-1);
	private Vector3 rightDir = new Vector3(1,0,0);
	private Vector3 leftDir = new Vector3(-1,0,0);

	// Update is called once per frame and grabs parameter from button presses
	public void update(int Direction) 
	{
		//==================================MOVE COMMANDS==========================================
		//avoid going past 25 (5 button presses same direction)
		// Waits for input from buttons and then adds the forces
		if (Direction == 1) {
			rigidbody.AddForce (leftDir * speed, ForceMode.VelocityChange);
		}
		if (Direction == 2) {
			rigidbody.AddForce (rightDir * speed, ForceMode.VelocityChange);
		}
		if (Direction == 3) {
			rigidbody.AddForce (upDir * speed, ForceMode.VelocityChange);
		}
		if (Direction == 4) {
			rigidbody.AddForce (downDir * speed, ForceMode.VelocityChange);
		}
		//end of move commands
	}
}

