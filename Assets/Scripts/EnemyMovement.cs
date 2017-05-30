using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for the enemy movement and what path they need to follow around the level 
//aswell as moveing from point to point and looking in that direction

public class EnemyMovement : MonoBehaviour {

	// speed is how fast the enemy moves
	public float speed = 5;
	//waittime is how long the enemy waits at each checkpoint
	public float waitTime = .3f;
	//turnspeed is how fast the enemy turns at each checkpoint
	public float turnSpeed = 90;


	//pathholder is the path the enemy is going to take
	public Transform pathHolder;

	//  Start()
	//Runs during initialisation
	//
	//Param:
	//			None
	//Return:
	//			Void

	void Start () {

		//this piece allows the enemy to know where the checkpoints are and the path to take while
		//also making sure it isnt sunk in the ground
		Vector3[] waypoints = new Vector3[pathHolder.childCount];
		for (int i = 0; i < waypoints.Length; i++) {
			waypoints [i] = pathHolder.GetChild (i).position;
			waypoints [i] = new Vector3 (waypoints [i].x, transform.position.y, waypoints [i].z);
		}
		//this start the guard to move from path to path
		StartCoroutine (FollowPath (waypoints));
		
	}
	//  FollowPath()
	//locates the next waypoint 
	//
	//Param:
	//			Vector3[] waypoints- the waypoints that outline the path the enemy needs to follow
	//Return:
	// 			IEnumerator
	IEnumerator FollowPath(Vector3[] waypoints) {
		transform.position = waypoints [0];
		//targetwaypoint targets thje waypoint and looks at its current location
		int targetWaypointIndex = 1;
		Vector3 targetWaypoint = waypoints [targetWaypointIndex];
		transform.LookAt (targetWaypoint);
		//this will have the enemy move towards the next waypoint
		while (true) {
			transform.position = Vector3.MoveTowards (transform.position, targetWaypoint, speed * Time.deltaTime);
			if (transform.position == targetWaypoint) {
				targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
				targetWaypoint = waypoints [targetWaypointIndex];
				//waitforseconds will have the enemy wait at each waypoint before moving to the next one
				yield return new WaitForSeconds (waitTime);
				//this will have the enemy rotate to look at the next waypoint
				yield return StartCoroutine (TurnToFace (targetWaypoint));
			}
			yield return null;
		}
	}
	// TurnToFace
	//this makes the enemy know which way to look for the next check point and face the next checkpoint
	//
	//Param:
	//			Vector3 lookTarget- the target that the enemey must look at, at each checkpoint
	//Return:
	//			IEnumerator
	IEnumerator TurnToFace(Vector3 lookTarget) {
		Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
		float targetAngle = 90 - Mathf.Atan2 (dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

		//allow the enemy to look both clockwise and anticlockwise
		while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f) {
			float angle = Mathf.MoveTowardsAngle (transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
			transform.eulerAngles = Vector3.up * angle;
			yield return null;
		}
	}
	//  OnDrawGizmos
	//this make it so you can see the paths in the game inspect and draws a line from path to path with spheres on each checkpoint
	//
	//Param:
	//			None
	//Return:
	//			Void
	void OnDrawGizmos() {
		Vector3 startPosition = pathHolder.GetChild (0).position;
		Vector3 previousPosition = startPosition;

		//this will draw a sphere on the empty game object labled waypoint 

		foreach (Transform waypoint in pathHolder) {
			Gizmos.	DrawSphere (waypoint.position, .3f);
			//this will draw a line from waypoint to waypoint
			Gizmos.DrawLine (previousPosition, waypoint.position);
			previousPosition = waypoint.position;
		}
		//this loops the waypoints
		Gizmos.DrawLine (previousPosition, startPosition);
	}
}
