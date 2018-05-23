using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public GameObject coin;
	// Use this for initialization
	void Start () {
		//Set name to coin
		name="Coin";
		//Create a random position
		Vector3 position = new Vector3 (Random.Range (-9f, 10.1f), Random.Range (-3f, 4.1f), 0);
		//Set coin position
		gameObject.transform.position = position;
	}
	


}
