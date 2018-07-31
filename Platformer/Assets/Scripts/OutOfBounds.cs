using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {
    public Animator cameraAnim;
    public GameObject player;
    public Rigidbody2D rigidBody;

    Vector2 zeroV;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.tries++;
            cameraAnim.enabled = true;
            cameraAnim.Play("Shake");
            player.transform.position = GameManager.instance.checkPoint;
            rigidBody.velocity = zeroV;
        }
    }
}
