using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {
    public Rigidbody2D rb;
    public GameObject player;
   
    public float forceSpeed;
	// Use this for initialization
	void Start () {

        rb = GetComponent < Rigidbody2D > ();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        //get a vector direction
        var dir = player.transform.position - transform.position;

        //radians
        var radian = Mathf.Atan2(dir.y, dir.x);

        //Covert radians to degrees
        float degress = radian * Mathf.Rad2Deg;

        //Set the missle rotation
        transform.rotation = Quaternion.Euler(0, 0, degress -90);

        rb.AddForce(dir*forceSpeed);

    }
}
