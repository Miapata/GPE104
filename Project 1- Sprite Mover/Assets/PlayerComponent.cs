using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerComponent : MonoBehaviour {
	//Speed
	public float speed  = 2.3f;
	//Coin prefab
	public GameObject coin;
	//Text object
	public Text text;

	//bool for shift
	public bool active = false;

	//score
	public int score;


	void Update () {

		//If "Q" is pressed
		if(Input.GetKeyDown(KeyCode.Q)){
			//Disable gameobject
			gameObject.SetActive (false);
		}


		//If shift is down
		if (Input.GetKeyDown (KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift)) {
			//set active to true
			active = true;
		}

		//If shift is up
		if (Input.GetKeyUp (KeyCode.LeftShift)||Input.GetKeyUp(KeyCode.RightShift)) {
			//set active to false
			active = false;
		}


		//If "space" is pressed
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Reset position to center
			transform.position = new Vector3 (0, 0, 0);
		}

		//If up arrow is down and shift is down
		if (Input.GetKeyDown (KeyCode.UpArrow) && active == true) {
			//Translate one unit
			transform.Translate (0, 1, 0);

		}
		//Input up arrow is down and active is false
		else if (Input.GetKey (KeyCode.UpArrow) && active == false) {
			//translate by speed
			transform.Translate (0,	speed, 0);
		}
		//If left arrow is down and shift is down
		if (Input.GetKeyDown (KeyCode.LeftArrow)&&active==true) {
			//Translate one unit
			transform.Translate (-1,0 , 0);

		}
		//If left arrow is down and active is false
		else if (Input.GetKey(KeyCode.LeftArrow)&&active==false) {
			//translate by speed
			transform.Translate (-speed,0,  0);
		}

		//If down arrow is down and shift is down
		if (Input.GetKeyDown (KeyCode.DownArrow)&&active==true) {
			transform.Translate (0,-1,  0);

		}
		//If down arrow is down and active is false
		else if (Input.GetKey(KeyCode.DownArrow)&&active==false) {
			//translate by speed
			transform.Translate (0,-speed,  0);
		}
		//If right arrow is down and shift is down
		if (Input.GetKeyDown (KeyCode.RightArrow)&&active==true) {
			//translate by one unit
			transform.Translate (1,0 , 0);

		}
		//If up arrow is right and active is false
		else if (Input.GetKey(KeyCode.RightArrow)&&active==false) {
			//translate by speed
			transform.Translate (speed,0 , 0);
		}



    }

	//Method for detecting collisions
	void OnCollisionEnter2D(Collision2D other){
		//If other collider is named Player
		if (other.gameObject.name == "Coin") {
			//Increase score
			score++;

			//Update score text
			text.text=("Score:" +score);

			//Set vector x,y to random range
			Vector3 position = new Vector3 (Random.Range (-9f, 10.1f), Random.Range (-3f, 4.1f), 0);
			//Spawn coin
			Instantiate (coin, position, Quaternion.identity);
			//Destroy current coin
			Destroy (other.gameObject);
		}

	}
}
