﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
	public GameObject missle,player,spawnRing;
	public Transform center;
	public Animator anim;
	// Use this for initialization

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
	}
	void Update(){
		if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {
			anim.enabled = false;
			GameObject newMissle = Instantiate (missle, transform.position, Quaternion.identity);
		
			Rigidbody2D rigidBody = newMissle.GetComponent<Rigidbody2D> ();
			newMissle.transform.position = new Vector3 (newMissle.transform.position.x, newMissle.transform.position.y, 0);
			var dir = player.transform.position - newMissle.transform.position;
			var radian = Mathf.Atan2 (dir.y, dir.x);
			float degress = radian * Mathf.Rad2Deg;
			newMissle.transform.rotation = Quaternion.Euler (0, 0, degress - 90);
			Vector2 direction = (player.transform.position - newMissle.transform.position);//W
			print(player.transform.position);
			var vel = direction.normalized;
			rigidBody.velocity = vel * 4;
			Destroy (gameObject);
		}
	

}
}
