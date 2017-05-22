using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyMovement : MonoBehaviour {
	//speed is how fast the player will move
	public float speed = 6.0f;

	public Text countText;
	public Text escapeText;
	private int count;

	bool disabled;


	void Start () {
		count = 1;
		SetCountText ();
		escapeText.text = "";
		Guard.OnGuardHasSpottedPlayer += Disabled;
	}
		
	//the if statement means if the player is on the ground and the player trys to move the character will move in the direction the player wants to go
	void Update () {

		Vector3 inputDirection = Vector3.zero;
		if (!disabled) {

			if (Input.GetKey (KeyCode.A)) {
				transform.position = transform.position += Vector3.forward * speed * Time.deltaTime; //new Vector3 (0, 0, 0.1f);
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.position = transform.position += Vector3.back * speed * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.S)) {
				transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.W)) {
				transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
				}
			}
		}
	void Disabled () {
		disabled = true;
	
	}

	//OnTriggerEnter means when the player enters the objects trigger it will disapear and deactivate
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count - 1;
			SetCountText ();
		}
	}
		
	void SetCountText () {
		countText.text = "Remaining Iteams Needed:" + count.ToString ();
		if (count >= 0) {
			escapeText.text = "Run!";
		}
	}
	void OnDestroy(){
		Guard.OnGuardHasSpottedPlayer -= Disabled;
	}
}
