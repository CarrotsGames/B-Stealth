using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyMovement : MonoBehaviour {
	//speed is how fast the player will move
	public float speed = 6.0f;
	//gravity is how much gravity is on the player
	public float gravity = 20.0f;
	//
	private Vector3 moveDirection = Vector3.zero;
	//the if statement means if the player is on the ground and the player trys to move the character will move in the direction the player wants to go
	void Update () {
		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}

	//OnTriggerEnter means when the player enters the objects trigger it will disapear and deactivate
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
		}
	}

}
