using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script rotates the Pickup

public class PickUpRotation : MonoBehaviour {
	//FixedUpdate happens at a delayed frame
	void FixedUpdate () {
		//this rotates the object at a speed of 5, 45, 1 per delayed frame
		transform.Rotate (new Vector3 (5, 45, 1) * Time.deltaTime);
	}
}
