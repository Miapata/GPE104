using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    //Jesus Christ
	// Use this for initialization
	void Start () {
        //Destroy after set time
		Destroy(gameObject, GameManager.instance.time);
	}

	//On collision with objects
     void OnCollisionEnter2D(Collision2D collision)
	{
		//Instantiate explosion
        Instantiate(GameManager.instance.explosion, collision.transform.position, Quaternion.identity);
		//Destroy the collided object
        Destroy(collision.gameObject);
		//Destroy laser
        Destroy(gameObject);
    }

}
