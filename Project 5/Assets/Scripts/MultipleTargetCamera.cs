using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour {

public Vector3 offset; //offset for camera
public List <Transform> targets; // targets transform
public Camera cam; // main camera
public float smoothTime; // damp smoothTime
public Bounds bounds; // bounds box
public float minZoom=40f; //minimun zoom
public float maxZoom=10f; // maximum zoom
public float zoomLimiter=50f; // zoom limiter
private Vector3 velocity; // ref velocity
void LateUpdate() {
 // If there are no targets we return
if(targets.Count==0)
return;

// Move camera function
Move();
// Zoom the camera
Zoom();
}

// We zoom using Lerp 
void Zoom()
{
// Get a new Zoom and grab the greatestDistance of the player
float newZoom = Mathf.Lerp(maxZoom,minZoom,GetGreatestDistance());
// change the orthographic size 
cam.orthographicSize= Mathf.Lerp(cam.orthographicSize,newZoom,Time.deltaTime);
}

// Get the greatest distance by comparing all of the targets
float GetGreatestDistance(){
        // If player is not null
        if (targets[0] != null)
        {
            // set bounds to the player
            bounds = new Bounds(targets[0].position, Vector3.zero);
        }

// Now we iterate through all of the targets and attempt to Find the Greatest Distance
for (int i = 0; i < targets.Count; i++)
{           // First check if it is not null
            if (targets[i] != null)
            {
                // Encapsulate the bounds
                bounds.Encapsulate(targets[i].position);
            }
}
// return the bounds float
return bounds.size.x;
}

// This is what makes the camera move
void Move(){

    // We use the GetCenterpoint function to get the center point
	Vector3 centerPoint= GetCenterPoint();
    
    // add the offset to a new vector
	Vector3 newPosition= centerPoint+offset;
    

    //Smooth the camera movement using SmoothDamp
	transform.position = Vector3.SmoothDamp(transform.position,newPosition, ref velocity,smoothTime);
}

// Get Center point
Vector3 GetCenterPoint(){

// if there is a target
if(targets.Count==1){

    // return the target's position
	return targets[0].position;
}
        // check if the target is not null
        if (targets[0] != null)
        {

            // set bounds to the target position 
            bounds = new Bounds(targets[0].position, Vector3.zero);
        }
// Jesus Christ 

 // Iterate through all the targets
 // It's important we convert the list To an array
for (int i = 0; i < targets.ToArray().Length; i++)

{           //Check if the index is not null
            if (targets.ToArray()[i] != null)
            {
                // Encapsulate the bounds
                bounds.Encapsulate(targets[i].position);
            }
}

// return the bounds
return bounds.center;
}

}
