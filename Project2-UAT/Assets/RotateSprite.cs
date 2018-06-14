using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour {


	// Point you want to have sprite rotate around
	public Transform player;

	// how far you want the sprite to be away from object
	public float length_fromObject = 1f;

	void Update() {

		// Get the direction between the sprite and mouse (aka the target position)
		Vector3 objectToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;

		// zero z axis since we are using 2d
		objectToMouseDir.z = 0; 

		// we normalize the new direction so you can make it the arm's length
		// then we add it to the player's position
		transform.position = player.position + (length_fromObject * objectToMouseDir.normalized);

		//Get diffrence of mouse position and srpite's position
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

		//Normalize it
		difference.Normalize();

		//Make a float and convert it to degrees
		float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

		//Rotate the sprite
		transform.rotation = Quaternion.RotateTowards();
		//Jesus
	}
}
