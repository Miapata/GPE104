using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	//Gameobjects
	public GameObject missle,player,spawnRing;

	//Spawning
	public Animator anim;

	// Use this for initialization
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
	}

	void Update(){

		//If the animation is finished
		if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {

			//Set the animator to false
			anim.enabled = false;

			//newMissle is spawned
			GameObject newMissle = Instantiate (missle, transform.position, Quaternion.identity);

			//Get the rigidBody
			Rigidbody2D rigidBody = newMissle.GetComponent<Rigidbody2D> ();

			//Set the Z to zero
			newMissle.transform.position = new Vector3 (newMissle.transform.position.x, newMissle.transform.position.y, 0);

			//direction for rotation
			var dir = player.transform.position - newMissle.transform.position;

			//Radians
			var radian = Mathf.Atan2 (dir.y, dir.x);

			//Convert to degrees
			float degress = radian * Mathf.Rad2Deg;

			//Change rotation
			newMissle.transform.rotation = Quaternion.Euler (0, 0, degress - 90);

			//Direction for velocity
			Vector2 direction = (player.transform.position - newMissle.transform.position);//W

			//Noramlize the velocity
			var vel = direction.normalized;

			//Set velocity
			rigidBody.velocity = vel * 4;

			//Destroy the gameobject
			Destroy (gameObject);
		}
	

}
}
