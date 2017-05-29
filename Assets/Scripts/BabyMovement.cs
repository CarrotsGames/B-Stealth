using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script controls the player movement aswell as the text that will come on screen that will guide the player

public class BabyMovement : MonoBehaviour {
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

	//when the game starts then these action will begin
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
		//this set it so the playe will move up instead of diaganal with movement
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize (forward);
		right = Quaternion.Euler (new Vector3 (0, 90, 0)) * forward;
}
		
	//Update means that this functions are updated every frame
	void Update () {
		//this make it so if the player is spoted the game will cut off the player controls
		Vector3 inputDirection = Vector3.zero;
		if (!disabled) {
			//if a key is pressed it will call the move function and move
			if (Input.anyKey)
				Move ();
		}
	}
	//Disabled disabled soemthing
	void Disabled () {
		//disabled is true
		disabled = true;
	
	}

	//OnTriggerEnter means when the player enters the objects trigger it will disapear and deactivate
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
		//SetCountText check to see if the count is equal to zero and then will activate the run and Carrot text
	void SetCountText () {
		countText.text = "Remaining Iteams Needed:" + count.ToString ();
		if (count >= 0) {
			escapeText.text = "Run!";
			carrotText.text = "Carrot";
		}
	}
	//OnDestory disables the player movement when scene
	void OnDestroy(){
		EnemyVision.OnEnemyHasSpottedPlayer -= Disabled;
	}
	//Move allows the player to move correctly with the Isometric camera angle
	void Move (){
		//this set a new keys and new Vertical and Horizontal key to make the player walk up not right aswell as mediate speed
	//	Vector3 direction = new Vector3 (Input.GetAxis ("HorizontalKey"), 0, Input.GetAxis ("VerticalKey"));
		Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis ("HorizontalKey");
		Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis ("VerticalKey");

		Vector3 heading = Vector3.Normalize (rightMovement + upMovement);

		transform.forward = heading;

		transform.position += rightMovement;
		transform.position += upMovement;

	}
}
