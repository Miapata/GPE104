using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : Photon.MonoBehaviour {


	// how far you want the sprite to be away from object
	public float length_fromObject = 1f;
    public static GameObject player;
    public static RotateSprite rs;
	void Update() {

		// Get the direction between the sprite and mouse (aka the target position)
		Vector3 objectToMouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - photonView.gameObject.transform.position;

		// zero z axis since we are using 2d
		objectToMouseDir.z = 0; 

		// we normalize the new direction so you can make it the arm's length
		// then we add it to the player's position
		transform.position = GameManager.instance.player.transform.position + (length_fromObject * objectToMouseDir.normalized);

		//Get diffrence of mouse position and srpite's position
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

		//Normalize it
		difference.Normalize();

		//Make a float and convert it to degrees
		float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        //Rotate the sprite
        transform.rotation = Quaternion.Euler(0, 0, rotation_z - 90);

	}
}
