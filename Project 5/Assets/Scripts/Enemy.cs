using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {

	public float sightDistance; // sight of enemy distance
public bool negative; // bool for forxtce

public Text text; // world space text

public bool beingHandeled; // for talking 
	public Rigidbody2D rigidBody; // rigidbody
	public Animator animator; // the animator of enemy
	public Vector2 force; // lunging force
	RaycastHit2D right; // Right raycast
	RaycastHit2D hit; // Left raycast

	// Update is called once per frame
	void Update () {
	 RaycastHit2D rightSight = Physics2D.Raycast(transform.position,  transform.right, sightDistance);
	 Debug.DrawRay(transform.position,transform.right*sightDistance,Color.blue);
	 if(rightSight.collider!=null){
	 if(rightSight.collider.gameObject.tag=="Player"){
		 
		 Lunge(!negative);
	 Debug.Log("Player in view : Right");
	 }
	 }
	 else{

		 // the player is not seen
		 animator.SetBool("playerSeen",false);
	 }
	 // left sight using RayCast
	 RaycastHit2D leftSight = Physics2D.Raycast(transform.position,  -transform.right, sightDistance);

	 // Draw the ray 
	 Debug.DrawRay(transform.position,-transform.right*sightDistance,Color.blue);

	 // If the collider is not null
	 if(leftSight.collider!=null){

		 // check if the collider's tag is "player"
	  if(leftSight.collider.gameObject.tag=="Player"){
		  
		  // lunge towards player
		  Lunge(negative);
		  
		  // Log status
	 Debug.Log("Player in view : Left");
	 }
	 }
	 else{

		 // the player is not seen
		 animator.SetBool("playerSeen",false);
	 }

if(beingHandeled==false){
	StartCoroutine("Talk");
}



	 
	}

// Lunge method, set the bool to true, and adds force
	void Lunge(bool negative){


		// Set animator bool to true
animator.SetBool("playerSeen",true);
	if(!negative){
// Add force 
rigidBody.AddForce(force,ForceMode2D.Impulse);
}


	if(negative){
rigidBody.AddForce(new Vector2(-force.x,force.y),ForceMode2D.Impulse);
}
	}

// Talk to player
	IEnumerator Talk(){

		// task is being handled
		beingHandeled=true;

		// Random wait time
	float waitTime = Random.Range(3,6);
	// wait for random seconds
yield return new WaitForSeconds(waitTime);

// Change text
text.text="Come get me ...";

// Start another coroutine
StartCoroutine("Wait");
}

// This let's the speech be visible for a few seconds before setting it to empty
IEnumerator Wait(){

// Wait for 2 seconds
yield return new WaitForSeconds(2);

// task is not being handeld anymore
beingHandeled=false;

// set text to blank
text.text="";
}
}




