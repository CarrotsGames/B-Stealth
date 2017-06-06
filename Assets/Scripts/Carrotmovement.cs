using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carrotmovement : MonoBehaviour {
	//speed is how fast the player will move
	public float speed = 6.0f;
	//makes it so the playerwill move up on a isometric camera angel
	Vector3 forward, right; 
	//the counter for the text
	public Text countText;
	//the Run! text for the screen
	public Text escapeText;
	//carrotText is the text that tells the player that they have a carrot
	public Text carrotText;
	//a count
	private int count;
	//disabled will disable something
	bool disabled;
	//--------------------------------------------------------------------------------------
	//  Start()
	// Runs during initialisation
	//Param:
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	void Start () {
		//the count is 1
		count = 1;
		//this action calls the SetCountText function
		SetCountText ();
		//this means the escape text isn't dispayed at the moment
		escapeText.text = "";
		//tis makes it so the Carrot text isnt displayed
		carrotText.text = "";
		//this means that the guard hasn't spotted the player on spawn
		EnemyVision.OnEnemyHasSpottedPlayer += Disabled;
		//this set it so the playe will move up instead of diagonal with movement
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize (forward);
		right = Quaternion.Euler (new Vector3 (0, 90, 0)) * forward;
	}
	//--------------------------------------------------------------------------------------	
	// Update ()
	// Runs every frame
	//Param:
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	void Update () {
		//this make it so if the player is spoted the game will cut off the player controls
		Vector3 inputDirection = Vector3.zero;
		if (!disabled) {
			//if a key is pressed it will call the move function and move
			if (Input.GetKey (KeyCode.A)) {
				Move ();
			} else if (Input.GetKey (KeyCode.W)) {
				Move ();
			} else if (Input.GetKey (KeyCode.S)) {
				Move ();
			} else if (Input.GetKey (KeyCode.D)) {
				Move ();
			}
		}
	}
	//--------------------------------------------------------------------------------------
	// Disabled ()
	//disables functions
	//Param:
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	void Disabled () {
		//disabled is true
		disabled = true;

	}
	//--------------------------------------------------------------------------------------
	// OnTriggerEnter()
	//player enters the objects trigger something will happen
	//Param:
	//		Collider Other- The Colldier of any objects that pass into this trigger
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	void OnTriggerEnter(Collider other) 
	{
		// if the player walks into an object that has a tag of Pick Up it will disable the object and add a count to the Text
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count - 1;
			//calling for the setcount text
			SetCountText ();
		}
	}
	//--------------------------------------------------------------------------------------
	// SetCount()
	//if the count is equal to zero and then will activate the run and Rocket text
	//
	//Param:
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	void SetCountText () {
		//displays Remaining Items Needed on the screen
		countText.text = "Remaining Gold Carrots To Steal:" + count.ToString ();
		//if the count equals 0 or less then display Run and carrot
		if (count >= 0) {
			escapeText.text = "Escape!";
			carrotText.text = "Carrot";
		}
	}
	//--------------------------------------------------------------------------------------
	// OnDestroy ()
	// destorys object
	//
	//Param:
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	void OnDestroy(){
		EnemyVision.OnEnemyHasSpottedPlayer -= Disabled;
	}
	//--------------------------------------------------------------------------------------
	//   Move()
	//Move allows the player to move correctly with the Isometric camera angle
	//
	//Param: 
	//			None
	//Return:
	//			Void
	//--------------------------------------------------------------------------------------
	void Move (){
		//this set a new keys and new Vertical and Horizontal key to make the player walk up not right aswell as mediate speed
		//	Vector3 direction = new Vector3 (Input.GetAxis ("HorizontalKey"), 0, Input.GetAxis ("VerticalKey"));
		Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis ("HorizontalKey");
		Vector3 upMovement = forward * speed * 1.5f * Time.deltaTime * Input.GetAxis ("VerticalKey");

		Vector3 heading = Vector3.Normalize (rightMovement + upMovement);

		transform.forward = heading;

		transform.position += rightMovement;
		transform.position += upMovement;

	}
}
