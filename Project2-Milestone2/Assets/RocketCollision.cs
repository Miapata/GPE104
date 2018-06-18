using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollision : MonoBehaviour {

	//Public gameobject
	public GameObject explosion;

	//Collision Method
	void OnCollisionEnter2D(Collision2D other){
		//If the collider is the player
		if (other.collider.name == "Player") {
			
			print ("+");

			//Instantiate the explosion
			Instantiate (explosion, other.gameObject.transform.position,Quaternion.identity);

			//Destroy the player
			Destroy (other.gameObject);

			//Destroy the missle
			Destroy (gameObject);
		}
	}


}
