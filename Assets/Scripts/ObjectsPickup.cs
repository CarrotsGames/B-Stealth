using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script makes it so if the object has a tag of Pick Up and the player waklks into it it will disable it and the door it is linked with

public class ObjectsPickup : MonoBehaviour {
	//doorToOpen is the door that the pickup is linked to
	public GameObject doorToOpen;
	//--------------------------------------------------------------------------------------
	// OnTriggerEneter
	//player enters the objects trigger something will happen
	//
	//Param:
	//			Collider Other- The Colldier of any objects that pass into this trigger
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	void OnTriggerEnter(Collider other) 
	{ 
		//if the object is taged with "Player" than
		if (other.tag == "Player") {
			
			//the door will disabled
			doorToOpen.SetActive (false);
			//and the gameobject will disabled
			this.gameObject.SetActive (false);
		}
	}
	//--------------------------------------------------------------------------------------
	//  OnDrawGizmos
	//Draws a line in the Scene view from the pick up to the door link to it
	//
	//Param:
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	void OnDrawGizmos () {
		if (doorToOpen) {
			//the line color is blue
			Gizmos.color = Color.blue;
			Gizmos.DrawLine (transform.position, doorToOpen.transform.position);
		}
	}
}