using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    float time;
	// Use this for initialization
	void Start () {
        time = GameManager.instance.time;
        Destroy(gameObject, time);
	}
     void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

}
