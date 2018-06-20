using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {
    //Rigidbody
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        

        //Gind the rigidbody
        rb = GetComponent < Rigidbody2D > ();

        //Find the player

	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.player) {
			//Get a vector direction
			Vector2 point2Target = (Vector2)transform.position - (Vector2)GameManager.instance.player.transform.position;

			//Normalize the target
			point2Target.Normalize ();

			//Find the cross product
			float value = Vector3.Cross (point2Target, transform.up).z;

			//If value is 0
			if (value > 0) {
				//set angular velocity
				rb.angularVelocity = GameManager.instance.enemy_RotateSpeed;
			}

        //Else if value is less than 0
        else if (value < 0)

            //Set angular
            rb.angularVelocity = -GameManager.instance.enemy_RotateSpeed;
        //Else

			else
            //Angular velocity is 0

            rb.angularVelocity = 0;

			//Set velocity to rotating speed and value
			rb.angularVelocity = GameManager.instance.enemy_RotateSpeed * value;

			//Velocity is transform up times the forceSpeed
			rb.velocity = transform.up * GameManager.instance.enemy_Speed;


		
    } else {
			
		}
}
}