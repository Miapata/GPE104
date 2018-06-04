using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		//If Left Arrow is pressed
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//Rotate the gameobject
			transform.Rotate (0, 0, 50 * Time.deltaTime);
		}
		//If right arrow is pressed
		if (Input.GetKey (KeyCode.RightArrow)) {
			//Rotate the gameobject
			transform.Rotate (0, 0, -50 * Time.deltaTime);
		}
		//If up arrow is pressed
		if (Input.GetKey (KeyCode.UpArrow)) {
			//Translate 
			transform.Translate (0, 4 * Time.deltaTime, 0);
		}
		//If down arrow is pressed
		if (Input.GetKey (KeyCode.DownArrow)) {
			//Translate
			transform.Translate (0, -4 * Time.deltaTime, 0);
		}
	}
}
