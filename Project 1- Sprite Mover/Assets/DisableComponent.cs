using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableComponent : MonoBehaviour {

	public MoveComponent move;
	public bool active=true;
	// Use this for initialization
	void Start () {
		//Set move to the component in this gameobject
		move = GetComponent<MoveComponent> ();
	}
	
	// Update is called once per frame
	void Update () {
		//If "P" is pressed
		if (Input.GetKeyDown (KeyCode.P)) {
			//Check if it's active
			if (active) {
				//disable it
				move.enabled = false;
				active = false;

			} else {
				//enable it
		move.enabled = true;
				active = true;
			}

		}
	}
}
