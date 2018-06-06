using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	public GameObject missle,player,spawnRing;
	public Transform center;
	public Animator anim;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 1);	
	}

	void Update(){
        //If the ring animation is finished
		if (anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 1) {
			//Spanw missle
			GameObject newMissle= Instantiate(missle,transform.position,Quaternion.identity);
		    //Multiply the worldspace by the quaternion    Vector right *rotation
            //Declare rigidbody2d
			Rigidbody2D rigidBody = newMissle.GetComponent<Rigidbody2D> ();

            //set z transform
			newMissle.transform.position = new Vector3 (newMissle.transform.position.x, newMissle.transform.position.y, 0);

            //get a vector direction
			var dir = player.transform.position - newMissle.transform.position;

            //radians
			var radian = Mathf.Atan2 (dir.y, dir.x);
            //Covert radians to degrees
			float degress = radian * Mathf.Rad2Deg;

            //Set the missle rotation
			newMissle.transform.rotation = Quaternion.Euler(0,0,degress-90);

            //dirction of velocity
			Vector2 direction = (player.transform.position - newMissle.transform.position);//W

            //normalize it
			var vel = direction.normalized;


			rigidBody.velocity = vel*4;
            
            
		}
	}
}
