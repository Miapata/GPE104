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

	public bool active = false;

	//score
	public int score;


	void Update () {

		//If "Q" is pressed
		if(Input.GetKeyDown(KeyCode.Q)){
			//Disable gameobject
			gameObject.SetActive (false);
		}



		if (Input.GetKeyDown (KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift)) {
			active = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)||Input.GetKeyUp(KeyCode.RightShift)) {
			active = false;
		}


		//If "space" is pressed
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Reset position to center
			transform.position = new Vector3 (0, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)&&active==true) {
			transform.Translate (0, 1, 0);

		}
		else if (Input.GetKey(KeyCode.UpArrow)&&active==false) {
			transform.Translate (0, speed, 0);
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)&&active==true) {
			transform.Translate (-1,0 , 0);

		}
		else if (Input.GetKey(KeyCode.LeftArrow)&&active==false) {
			transform.Translate (-speed,0,  0);
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)&&active==true) {
			transform.Translate (0,-1,  0);

		}
		else if (Input.GetKey(KeyCode.DownArrow)&&active==false) {
			transform.Translate (0,-speed,  0);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)&&active==true) {
			transform.Translate (1,0 , 0);

		}
		else if (Input.GetKey(KeyCode.RightArrow)&&active==false) {
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
