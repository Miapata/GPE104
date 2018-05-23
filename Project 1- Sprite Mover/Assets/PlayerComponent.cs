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

	//score
	public int score;


	void Update () {

		//If "Q" is pressed
		if(Input.GetKeyDown(KeyCode.Q)){
			//Disable gameobject
			gameObject.SetActive (false);
		}

		//If "space" is pressed
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Reset position to center
			transform.position = new Vector3 (0, 0, 0);
		}


		//If "up Arrow" is pressed
        if (Input.GetKey(KeyCode.UpArrow))
        {
			//Check if "Shift" is pressed
            if (Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift))
            {
				//Translate by one unit
                transform.Translate(0, 1, 0);
            }
            else
            {
				//Smoother translate
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }

		//If "down arrow" is pressed
        if (Input.GetKey(KeyCode.DownArrow))
        {
			//Check if Shift is pressed
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
				//translate one unit
                transform.Translate(0, -1, 0);
            }
            else
            {
				//translate smoother
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
        }
		//If "right arrow" is pressed
        if (Input.GetKey(KeyCode.RightArrow))
        {
			//Check if Shift is pressed
            if (Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift))
			{
				//Translate by one unit
                transform.Translate(1, 0, 0);
            }
            else
			{
				//Smoother translate
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }
		
		//If left arrow is pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
			//Check if Shift is pressed
            if (Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift))
            {
				//Translate by one unit
                transform.Translate(-1 , 0, 0);
            }
            else
            {
				//Smoother translate
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
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
