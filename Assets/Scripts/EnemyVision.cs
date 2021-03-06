﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the what the enemy can see and how it will interact with the player and the objects in the level

public class EnemyVision : MonoBehaviour {
	
	public static event System.Action OnEnemyHasSpottedPlayer;

	//Time before player losses if spoted
	public float timeToSpotPlayer = .5f;

	//These  setting are the Spotlights Distance
	public Light spotlight;
	//how far the enemy can see
	public float viewDistance;
	//these setting are for the enemy's Mask and Angle
	public LayerMask viewMask;
	//the angle of the view
	float viewAngle;
	//how long the player can be seen before gameover
	float playerVisibleTimer;
	//the player
	Transform player;
	//this is the defult color of the spotlight
	Color originalSpotLightColour;



	//  --------------------------------------------------------------------------------------
	// Start()
	//this checks if the player is in range and sets the default color of the spotlight
	//Runs during initialisation
	//Param:
	//			None
	//Return:
	//			Void
	// --------------------------------------------------------------------------------------

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		viewAngle = spotlight.spotAngle;
		originalSpotLightColour = spotlight.color;

	}
	// --------------------------------------------------------------------------------------
	// 		Update ()
	//runs everyframe
	// this makes it so if the player isnt in the spotlight it will be normal and if the player is in the spotlight it will be red
	//Param:
	//			None
	//Return:
	//			Void
	// --------------------------------------------------------------------------------------

	void Update() {
		//if the player  can be scene then gameover
		if (CanSeePlayer ()){
			playerVisibleTimer += Time.deltaTime;
		}else {
				//if the player can't be seen the play on
			playerVisibleTimer -= Time.deltaTime;
		}
		playerVisibleTimer = Mathf.Clamp (playerVisibleTimer, 0, timeToSpotPlayer);
		spotlight.color = Color.Lerp (originalSpotLightColour, Color.red, playerVisibleTimer / timeToSpotPlayer);

		if (playerVisibleTimer >= timeToSpotPlayer) {
			if (OnEnemyHasSpottedPlayer != null) {
				OnEnemyHasSpottedPlayer ();
			}
		}
	}
	//--------------------------------------------------------------------------------------
	// CanSeePlayer ()
	//if the player is in the guards view angle than the enemy can see the player and if not then it can't see the player
	//
	//Param:
	//			None
	//Return:
	//			Bool
	//--------------------------------------------------------------------------------------
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
	//--------------------------------------------------------------------------------------	
	// OnDrawGizmos()
	// this drawns the enemys raycast so the line can be seen in the inspector and the line is blue
	//
	//Param:
	//			None
	//Return;
	//			Void
	//--------------------------------------------------------------------------------------
	void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawRay (transform.position, transform.forward * viewDistance);

	}
}