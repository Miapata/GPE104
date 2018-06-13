using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //After two seconds, destroy
        Destroy(gameObject, 2);
	}
	

}
