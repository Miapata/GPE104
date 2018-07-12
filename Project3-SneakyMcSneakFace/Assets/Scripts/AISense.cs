using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISense : MonoBehaviour 
{
	// data
	public float viewDistance = 10; // How far they can see
	public float fieldOfView = 60; // View angle (Field of View)

	// Components
	private Transform tf;

	// Use this for initialization
	void Start()
	{
		tf = GetComponent<Transform>();
	}

	public bool CanSee(GameObject player)
	{
		// If they do not have a collider, they are invisible
		Collider2D targetCollider = player.GetComponent<Collider2D>();
		if (targetCollider == null)
		{
			return false;
		}

		// If they are outside the view angle, we cannot see them
		// To check, we need the vector to our target, and compare that angle to our forward vector
		Transform targetTransform = player.GetComponent<Transform>();
		Vector3 vectorToTarget = targetTransform.position - tf.position;

		float angle = Vector3.Angle(vectorToTarget, tf.right);
		Debug.Log("CanSee angle=" + angle);

		if (Vector3.Angle(vectorToTarget, tf.right) >= fieldOfView)
		{
			return false;
		}


		// If they are in our field-of-view (thus we could get here), 
		//     raycast to make sure nothing is blocking our view
		RaycastHit2D hitInfo = Physics2D.Raycast(tf.position, vectorToTarget, viewDistance);

		// if our raycast hit nothing, we can't see them
		if (hitInfo.collider == null)
		{
			return false;
		}

		// If our raycast hit them first, then we can see them
		if (hitInfo.collider == targetCollider)
		{
			return true;
		}

		// otherwise, if we hit something else we failed to see them
		return false;
	}

    //Check if the enemy can hear our foosteps
    public bool CanHear(GameObject player,int volume)
    {
        //Get the dist between the player and enemy
        float dist = Vector3.Distance(player.transform.position, transform.position);

        //get the magnitude of the vector
        
        Debug.Log(dist);

        //If the magnitude is less than than the volume
        if (dist < volume)
        {
            Debug.Log("Player Heard");

            //Return true
            return true;
        }
        else
        {

            //Return false
            return false;
        }
        
    }
}
