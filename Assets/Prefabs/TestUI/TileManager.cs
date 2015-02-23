using UnityEngine;
using System.Collections;

/* Creator: Michael
 * Object: Attach to "TestUI" element
 * Public Variables: player - player GameObject
 * Interaction: Button "onclick()" method calls "executeTile()" which adds a vector to the player based
 * 				on the first tile in the Queue.
 *
 * Usage/Description: This script determines player motion in conjuction with the UI. It is also responsible for
 * 		  			  creating and managing the fields of the vectorTiles and their relevant Queue.
 */

public class TileManager : MonoBehaviour {

	// Reference to player game object
	public GameObject player;

	// Standard vectors
	private Vector3 xStd = new Vector3(5,0,0);
	private Vector3 yStd = new Vector3(0,0,5);

	// Private variables to manage the Tile Queue
	private vectorTile first = null;
	private vectorTile build = new vectorTile ();
	private int size = 0;
	private bool UIActive = false;

	// A vectorTile class to manage the associated fields of each tile object
	public class vectorTile {
		// Stores an X,Y magnitude and a pointer to the next tile in the Queue
		public int Xmag;
		public int Ymag;
		public vectorTile next;

		// Constructors
		public vectorTile() {
			Xmag = 0;
			Ymag = 0;
			next = null;
		}

		public vectorTile(int X, int Y) {
			Xmag = X;
			Ymag = Y;
			next = null;
		}
	}
		
	// Following methods used to modify values of a "build" tile
	// Values for Xmag and Ymag must be between [-5,5]
	public void increaseXmag (){
		if(!(build.Xmag>=5)) build.Xmag++;
	}
	
	public void decreaseXmag (){
		if(!(build.Xmag<=-5)) build.Xmag--;
	}
	
	public void increaseYmag (){
		if(!(build.Ymag>=5)) build.Ymag++;
	}
	
	public void decreaseYmag (){
		if(!(build.Ymag<=-5)) build.Ymag--;
	}

	// A method to addTiles to the Queue
	public void addTile(){
		// If UI Window is closed, do nothing
		if(!UIActive) return;
		// If current "build" tile has no values, do nothing.
		if ((build.Xmag == 0) && (build.Ymag == 0)) return;

		// Otherwise constructs a new tile based on current values of "build" tile
		vectorTile newTile = new vectorTile(build.Xmag, build.Ymag);

		// If Queue is empty, add it to beginning
		if(size == 0) {
			first = newTile;
		// If Queue is too big, add nothing
		} else if (size >= 6) { return; }
		// If not, step through Queue till end and add to end of Queue
		else {
			vectorTile temp = new vectorTile();
			temp = first;
			while(temp.next != null){
				temp = temp.next;
			}
			temp.next = newTile;
		}
		// Increment size
		size++;
		// Reset values of "build"
		build.Xmag = build.Ymag = 0;
		// DEBUG
		printQueue();
	}

	// A method to call to execture the first tile
	public void executeTile(){
		// If no tiles, quit
		if(size == 0) return;
		// Otherwise, remove first tile and add vector to Player
		else {
			player.rigidbody.AddForce (first.Xmag * xStd, ForceMode.VelocityChange);
			player.rigidbody.AddForce (first.Ymag * yStd, ForceMode.VelocityChange);
			first = first.next;
			size--;
		}
		// DEBUG
		printQueue ();
	}

	// Used to change UIActive variable
	public void changeUIState(bool x){
		UIActive = x;
		if(x)build.Xmag = build.Ymag = 0;
	}

	// DEBUG
	public void printQueue(){
		string s = "Your Queue is: ";
		vectorTile temp = new vectorTile();
		temp = first;
		while(temp != null){
			s = s + "(" + temp.Xmag + ", " + temp.Ymag + ") ";
			temp = temp.next;
		}
		Debug.Log(s);
		
	}
}