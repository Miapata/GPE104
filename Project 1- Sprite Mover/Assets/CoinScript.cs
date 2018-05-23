using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	public GameObject coin;
	// Use this for initialization
	void Start () {

			Vector3 position = new Vector3 (Random.Range (-9f, 10.1f), Random.Range (-3f, 4.1f), 0);
			var instance=Instantiate (coin, position, Quaternion.identity);
	}
	


}
