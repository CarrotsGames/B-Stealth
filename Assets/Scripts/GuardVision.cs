using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVision : MonoBehaviour {
	//The guard calls this event when the player is in the spotlight for more than .5 seconds
	public static event System.Action OnGuardHasSpottedPlayer;

	//Time before player losses if spoted
	public float timeToSpotPlayer = .5f;


	//These  setting are the Spotlights Distance
	public Light spotlight;
	public float viewDistance;
	//these setting are for the guards Mask and Angle
	public LayerMask viewMask;
	float viewAngle;
	float playerVisibleTimer;

	Transform player;
	//this is the defult color of the spotlight
	Color originalSpotLightColour;

	//this checks if the player is in range and sets the default color of the spotlight
	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		viewAngle = spotlight.spotAngle;
		originalSpotLightColour = spotlight.color;

	}
	//this makes it so if the player isnt in the spotlight it will be normal and if the
	//player is in the spotlight it will be red 
	void Update() {
		if (CanSeePlayer ()){
			playerVisibleTimer += Time.deltaTime;
		}else {
			playerVisibleTimer -= Time.deltaTime;
		}
		playerVisibleTimer = Mathf.Clamp (playerVisibleTimer, 0, timeToSpotPlayer);
		spotlight.color = Color.Lerp (originalSpotLightColour, Color.red, playerVisibleTimer / timeToSpotPlayer);

		if (playerVisibleTimer >= timeToSpotPlayer) {
			if (OnGuardHasSpottedPlayer != null) {
				OnGuardHasSpottedPlayer ();
			}
		}
	}

	//CanSeePlayer makes it so that if the player is in the guards view angle than the guard 
	//can see the player and if not then it can't see the player
	bool CanSeePlayer() {
		if (Vector3.Distance(transform.position,player.position)< viewDistance) {
			Vector3 dirToPlayer = (player.position - transform.position).normalized;
			float angleBetweenGuardAndPlayer = Vector3.Angle (transform.forward, dirToPlayer);
			if(angleBetweenGuardAndPlayer < viewAngle / 2f) {
				if (!Physics.Linecast(transform.position,player.position, viewMask)) {
					return true;
				}
			}
		}
		return false;
	}
		

	//this make it so you can see the paths in the game inspect and draws a line from path
	//to path with spheres on each checkpoint
	void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawRay (transform.position, transform.forward * viewDistance);

	}
}
