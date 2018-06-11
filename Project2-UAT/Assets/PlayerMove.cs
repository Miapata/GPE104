using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    Rigidbody2D rb;
    public GameObject laser,center;
    public float rotateSpeed, movementSpeed,laserSpeed;
	// Use this for initialization
	void Start() {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(0, 0,rotateSpeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, movementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -movementSpeed * Time.deltaTime, 0);
 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            
           var laserInstance= Instantiate(laser,center.transform.position,transform.rotation);
            
            rb= laserInstance.GetComponent<Rigidbody2D>();
            rb.velocity = transform.up*laserSpeed;
            
        }

    }
}
