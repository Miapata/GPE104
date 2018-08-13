using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour
{
	public float timeToWait; // wait time

	// Called after each frame
void LateUpdate(){

	// Checks the parent
	if(transform.parent==null){

		// Destroy gameobject after certain time
	GameObject.Destroy(gameObject,timeToWait);
	}
}

}

