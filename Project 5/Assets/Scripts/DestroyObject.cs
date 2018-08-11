using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour
{
	public float timeToWait;

	// Use this for initialization
	void Update(){

		//Get rid of the object after a few seconds
		//Only called when the missle gets destroyed
		if (transform.parent == null) {
			timeToWait -= Time.deltaTime;
			if (timeToWait <= 0) {
				PhotonNetwork.Destroy (gameObject);
			}
		}
	}

}

