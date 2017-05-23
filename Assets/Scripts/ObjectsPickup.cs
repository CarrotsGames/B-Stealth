using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPickup : MonoBehaviour {

	public GameObject doorToOpen;


	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player") {
			//Debug.Log ("Run");

			doorToOpen.SetActive (false);
			this.gameObject.SetActive (false);


		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			}
		}
	}

	void OnDrawGizmos () {
		if (doorToOpen) {
			Gizmos.color = Color.blue;
			Gizmos.DrawLine (transform.position, doorToOpen.transform.position);
		}
	}
}