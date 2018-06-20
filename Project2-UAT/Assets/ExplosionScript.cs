using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Get particle system
		var main= gameObject.GetComponent<ParticleSystem>().main;

		//Set color to random
		main.startColor=GameManager.instance.colors[Random.Range(0,4)];

		//After two seconds, destroy
        Destroy(gameObject, 2);
	}
	

}
