using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script makes it so if the object has a tag of Pick Up and the player waklks into it it will disable it and the door it is linked with

public class ObjectsPickup : MonoBehaviour {
	//doorToOpen is the door that the pickup is linked to
	public GameObject doorToOpen;

	//OnTriggerEnter is if the player enters the trigger
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
	//OnDrawGizmo draws a line from the object this script is on to the door it is linked with
	void OnDrawGizmos () {
		if (doorToOpen) {
			//the line color is blue
			Gizmos.color = Color.blue;
			Gizmos.DrawLine (transform.position, doorToOpen.transform.position);
		}
	}
}