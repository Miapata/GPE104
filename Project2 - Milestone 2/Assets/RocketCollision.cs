using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollision : MonoBehaviour {
	public GameObject explosion;
	void OnCollisionEnter2D(Collision2D other){

		if (other.collider.name == "Player") {
			print ("+");
			Instantiate (explosion, other.gameObject.transform.position,Quaternion.identity);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}


}
