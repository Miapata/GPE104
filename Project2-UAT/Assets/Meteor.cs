using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {
    public GameObject player;
    public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);


        //Get direction
        Vector2 direction = (player.transform.position - transform.position);//W
        
        //normalize it
        var vel = direction.normalized;

        //Set the velocity
       rb.velocity = vel * 2;
    }
	

}
