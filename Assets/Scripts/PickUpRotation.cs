using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script rotates the Pickup

public class PickUpRotation : MonoBehaviour {

	//--------------------------------------------------------------------------------------
	//  FixedUpdate() 
	//happens at a fixed frame
	//
	//Param:
	//			None
	//Return
	//			Void
	//--------------------------------------------------------------------------------------
	void FixedUpdate () {
		//this rotates the object at a speed of 5, 45, 1 per delayed frame
		transform.Rotate (new Vector3 (45, 45, 45) * Time.deltaTime);
	}
}
