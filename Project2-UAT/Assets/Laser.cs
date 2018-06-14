using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
  
	// Use this for initialization
	void Start () {
        
		Destroy(gameObject, GameManager.instance.time);
	}
     void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

}
