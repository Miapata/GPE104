using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveComponent : MonoBehaviour {
	public float speed  = 2.3f;
	// Update is called once per frame
	void Update () {

		//If escape key is pressed
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}



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
}
