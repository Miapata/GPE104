using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    
    //Rigidbody2D
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        

        //find rigidbody
        rb = GetComponent<Rigidbody2D>();

        //set position to zero on z
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //Get direction
		Vector2 direction = (GameManager.instance.player.transform.position - transform.position);//W
        
        //normalize it
        var vel = direction.normalized;

        //Set the velocity
       rb.velocity = vel * 2;
    }
	

}
