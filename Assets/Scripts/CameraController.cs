using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	//This is the player the camera needs to follow
	public GameObject player;
	//this is the offset of the camera and the player
	private Vector3 offset;

	// Start()
	//Runs during initialisation
	//
	//Param:
	//			None
	//Return:
	//			Void
	void Start () {
		//this is the offset of the camera to the player to stay at a certain distance to the player
		offset = transform.position - player.transform.position;
	}
	//  LateUpdate()
	// Runs after Update function
	//
	//Param:
	//			None
	//Return:
	//			Void
	void LateUpdate () {
		//this makes it so the camera will stay with the player
		transform.position = player.transform.position + offset;
	}
}
