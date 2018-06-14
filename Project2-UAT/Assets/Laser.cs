using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    //Jesus Christ

    public GameObject explosion;
	// Use this for initialization
	void Start () {
        
		Destroy(gameObject, GameManager.instance.time);
	}
     void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, collision.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

}
