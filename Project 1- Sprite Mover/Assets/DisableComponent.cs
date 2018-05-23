using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableComponent : MonoBehaviour {

	public PlayerComponent player;
	public bool active=true;
	// Use this for initialization
	void Start () {
		//Set move to the component in this gameobject
		player = GetComponent<PlayerComponent> ();
	}
	
	// Update is called once per frame
	void Update () {
		//If "P" is pressed
		if (Input.GetKeyDown (KeyCode.P)) {
			//Check if it's active
			if (active) {
				//disable it
				player.enabled = false;
				active = false;

			} else {
				//enable it
		player.enabled = true;
				active = true;
			}

		}
	}
}
