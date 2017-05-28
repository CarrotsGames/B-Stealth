using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRotation : MonoBehaviour {

	void FixedUpdate () {

		transform.Rotate (new Vector3 (5, 45, 1) * Time.deltaTime);
	}
}
