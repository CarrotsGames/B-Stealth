using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {
	//The guard calls this event when the player is in the spotlight for more than .5 seconds
	public static event System.Action OnGuardHasSpottedPlayer;

	// speed is how fast the gaurd moves
	public float speed = 5;
	//waittime is how long the guard waits at each checkpoint
	public float waitTime = .3f;
	//turnspeed is how fast the guard turns at each checkpoint
	public float turnSpeed = 90;
	//Time before player losses if spoted
	public float timeToSpotPlayer = .5f;


	//These  setting are the Spotlights Distance
	public Light spotlight;
	public float viewDistance;
	//these setting are for the guards Mask and Angle
	public LayerMask viewMask;
	float viewAngle;
	float playerVisibleTimer;

	//pathholder is the path the guard is going to take
	public Transform pathHolder;
	Transform player;
	//this is the defult color of the spotlight
	Color originalSpotLightColour;

	//this checks if the player is in range and sets the default color of the spotlight
	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		viewAngle = spotlight.spotAngle;
		originalSpotLightColour = spotlight.color;

		//this piece allows the guard to know where the checkpoints are and the path to take while
		//also making sure it isnt sunk in the ground
		Vector3[] waypoints = new Vector3[pathHolder.childCount];
		for (int i = 0; i < waypoints.Length; i++) {
			waypoints [i] = pathHolder.GetChild (i).position;
			waypoints [i] = new Vector3 (waypoints [i].x, transform.position.y, waypoints [i].z);
		}
		//this start the guard to move from path to path
		StartCoroutine (FollowPath (waypoints));

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

	//this locates the path and tells the guard to look at each point before moving to it
	IEnumerator FollowPath(Vector3[] waypoints) {
		transform.position = waypoints [0];

		int targetWaypointIndex = 1;
		Vector3 targetWaypoint = waypoints [targetWaypointIndex];
		transform.LookAt (targetWaypoint);

		while (true) {
			transform.position = Vector3.MoveTowards (transform.position, targetWaypoint, speed * Time.deltaTime);
			if (transform.position == targetWaypoint) {
				targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
				targetWaypoint = waypoints [targetWaypointIndex];
				yield return new WaitForSeconds (waitTime);
				yield return StartCoroutine (TurnToFace (targetWaypoint));
			}
			yield return null;
		}
	}
	//this makes the guard know which way to look for the next check point
	IEnumerator TurnToFace(Vector3 lookTarget) {
		Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
		float targetAngle = 90 - Mathf.Atan2 (dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;
		//allow the guard to look both clockwise and anticlockwise

		while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f) {
			float angle = Mathf.MoveTowardsAngle (transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
			transform.eulerAngles = Vector3.up * angle;
			yield return null;
		}
	}
	//this make it so you can see the paths in the game inspect and draws a line from path
	//to path with spheres on each checkpoint
	void OnDrawGizmos() {
		Vector3 startPosition = pathHolder.GetChild (0).position;
		Vector3 previousPosition = startPosition;

		foreach (Transform waypoint in pathHolder) {
			Gizmos.DrawSphere (waypoint.position, .3f);
			Gizmos.DrawLine (previousPosition, waypoint.position);
			previousPosition = waypoint.position;
		}
		Gizmos.DrawLine (previousPosition, startPosition);

		Gizmos.color = Color.blue;
		Gizmos.DrawRay (transform.position, transform.forward * viewDistance);

	}
}
