using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {


    // Function : OnTriggerEnter2D
    // 
    // |This is how we are able to set the check point. When the player dies
    // | they will respawn at this checkpoint.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.checkPoint = transform.position;
        }
    }
}
