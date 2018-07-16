﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public float speed;
	public float jumpForce;
	public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//set x to input axis
		float x= Input.GetAxis("Horizontal");

		//transform the player
		transform.position += Vector3.right * x * Time.deltaTime*speed;


		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}

	}
}