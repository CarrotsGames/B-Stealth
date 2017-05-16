using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemYPatrol : MonoBehaviour {

	public Transform[] waypoint;
	public float patrolSpeed = 3f;
	public bool loop = true;
	public float damingLook = 6.0f;
	public float pauseDuration = 0;

	private float curTime;
	private int currentWaypoint = 0;
	private CharacterController character;

	void Start () {
		character = GetComponent<CharacterController> ();
	}
	void Update () {
		if(currentWaypoint<waypoint.Length){
			patrol();
		}else{
			if(loop){
				currentWaypoint = 0;
			}
		}
	}
	void patrol (){

		Vector3 target = waypoint [currentWaypoint].position;
		target.y = transform.position.y;
		Vector3 moveDirection = target - transform.position;

		if(moveDirection.magnitude < 0.5f){
			if (curTime == 0)
				curTime = Time.time;
			if ((Time.time - curTime) >= pauseDuration){
				currentWaypoint = 0;
			}
		}else{
			var rotation = Quaternion.LookRotation (target - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damingLook);
			character.Move (moveDirection.normalized * patrolSpeed * Time.deltaTime);
		}
	}
}
