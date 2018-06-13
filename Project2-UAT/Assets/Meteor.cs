using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {
    //Player
    public GameObject player;
    
    //Rigidbody2D
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        //Use tag to find player
        player = GameObject.FindGameObjectWithTag("Player");

        //find rigidbody
        rb = GetComponent<Rigidbody2D>();

        //set position to zero on z
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //Get direction
        Vector2 direction = (player.transform.position - transform.position);//W
        
        //normalize it
        var vel = direction.normalized;

        //Set the velocity
       rb.velocity = vel * 2;
    }
	

}
