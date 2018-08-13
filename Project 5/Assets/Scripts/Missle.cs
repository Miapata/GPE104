using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : Photon.MonoBehaviour
{

	public GameObject particleSystem; // the missile's trail
    public float moveSpeed; //move speed
    public float rotatingSpeed; // rotate speed
    private Vector3 mousePosition; // mouse position

    Rigidbody2D rb; // our RigidBody2D

    // Use this for initialization
    void Start()
    {
            // set rb to our RigidBody2D
            rb = GetComponent<Rigidbody2D>();
        
   
    }

	// Updates every frame
    private void Update()
    {
		// Follow the mouse constantly
        transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition),0.2f);

		// Get the distance of our mouse position and our position
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

		// We normalize it
        difference.Normalize();

		// Some math to get the degrees we should rotate on the Z axis
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

		// Rotate 
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z-90);
    }
		
	// Checks if we enter any collider
    private void OnTriggerEnter2D(Collider2D collider)
    {
		// Have we hit something that is not our player?
        if (collider.gameObject.tag!="Player")
        {
			// Detach the particle system
			DetachParticleSystem();

			// Destroy our Missile
            Destroy(gameObject);
        }
    }

	// We detach the particle system by calling this method

	void DetachParticleSystem(){
		
		// Set the parent to none
		particleSystem.transform.parent = null;
	}

}
