using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    //  |Intended Use: Allows for the camera to smoothly follow
    //  |a target. Attach this to your camera and apply a
    //  |target to it.


    //----VARIABLES----
    // | This scripts needs a game object, a velocity, and a smooth time.
    // | The gameobject will be the target and the velocity will be a Vector3.
    // | the smoothTime float is how fast the Camera will follow our target.

    public Vector3 velocity;
    public float smoothTime;

    public GameObject target;

    // Late update is called after every frame.
    void LateUpdate () {

        //transforms the camera 
        if (target.activeInHierarchy == true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, smoothTime);
        }
	}
}
