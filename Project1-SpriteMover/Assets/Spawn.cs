using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	//Gameobject variable
	public GameObject coin;
	void Start(){
		//If coin is in not in game, spawn a coin
		if (coin.scene.name==null) {
			//spawn a coin
			Instantiate (coin);
		}
	}
}
