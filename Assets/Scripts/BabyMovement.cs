using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyMovement : MonoBehaviour {
	//speed is how fast the player will move
	public float speed = 6.0f;

	Vector3 forward, right; 

	public Text countText;
	public Text escapeText;
	//carrotText is the text that tells the player that they have a carrot
	public Text carrotText;

	private int count;
	//disabled will disable something
	bool disabled;


	void Start () {
		count = 1;
		SetCountText ();
		escapeText.text = "";
		carrotText.text = "";
		Guard.OnGuardHasSpottedPlayer += Disabled;

		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize (forward);
		right = Quaternion.Euler (new Vector3 (0, 90, 0)) * forward;
}
		
	//the if statement means if the player is on the ground and the player trys to move the character will move in the direction the player wants to go
	void Update () {

		Vector3 inputDirection = Vector3.zero;
		if (!disabled) {

			if (Input.anyKey)
				Move ();

//			if (Input.GetKey (KeyCode.A)) {
//				transform.position = transform.position += Vector3.forward * speed * Time.deltaTime; //new Vector3 (0, 0, 0.1f);
//			}
//			if (Input.GetKey (KeyCode.D)) {
//				transform.position = transform.position += Vector3.back * speed * Time.deltaTime;
//			}
//			if (Input.GetKey (KeyCode.S)) {
//				transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
//			}
//			if (Input.GetKey (KeyCode.W)) {
//				transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
//				}
//			}
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
			carrotText.text = "Carrot";
		}
	}
	void OnDestroy(){
		Guard.OnGuardHasSpottedPlayer -= Disabled;
	}

	void Move (){
		Vector3 direction = new Vector3 (Input.GetAxis ("HorizontalKey"), 0, Input.GetAxis ("VerticalKey"));
		Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis ("HorizontalKey");
		Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis ("VerticalKey");

		Vector3 heading = Vector3.Normalize (rightMovement + upMovement);

		transform.forward = heading;

		transform.position += rightMovement;
		transform.position += upMovement;

	}
}
