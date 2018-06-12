using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public Spawn spawn;
    Rigidbody2D rb;
    public GameObject laser,center,explosion;
    public float rotateSpeed, movementSpeed,laserSpeed;
	// Use this for initialization
	void Start() {
        spawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawn>();
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

     void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion,transform.position,Quaternion.identity);
            foreach (GameObject enemy in spawn.enemyList)
            {
                spawn.enemyList.Remove(enemy);
                Destroy(enemy);
            }
        }
    
}
