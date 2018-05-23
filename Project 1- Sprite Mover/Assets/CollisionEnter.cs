using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnter : MonoBehaviour {
	//Declare variable coin
	public GameObject coin;


	//Collision Detection 
	void OnCollisionEnter2D(Collision2D other){
		//If other collider is named Player
		if (other.gameObject.name == "Player") {

			//Set vector x,y to random range
			Vector3 position = new Vector3 (Random.Range (-9f, 10.1f), Random.Range (-3f, 4.1f), 0);
			//Spawn coin
			Instantiate (coin, position, Quaternion.identity);
			//Destroy current coin
			Destroy (gameObject);
		}

	}
}
