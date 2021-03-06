using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {
	private const float LANE_DISTANCE = 3.0f;

	//Movement
	private CharacterController controller;
	private float jumpForce=4.0f;
	private float gravity = 12.0f;
	private float verticleVelocity;
	private float speed = 7.0f;
	private int desiredLane = 1; //0 = Left, 1 = Middle, 2 = Right

	private void Start(){
		controller = GetComponent<CharacterController> ();
	}

	private void Update(){
		//Gather the inputs on which lane we should be
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			MoveLane (false);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			MoveLane (true);
		}

		//Calculate where we should be in the future
		Vector3 targetPosition= transform.position.z*Vector3.forward;
		if (desiredLane == 0)
			targetPosition += Vector3.left * LANE_DISTANCE;
		else if (desiredLane == 2)
			targetPosition += Vector3.left * LANE_DISTANCE;

		//Lets calculate our move delta
		Vector3
	}

	private void MoveLane(bool goingRight){
		desiredLane += (goingRight) ? 1 : -1;
		desiredLane = Mathf.Clamp (desiredLane, 0, 2);
	}

}
