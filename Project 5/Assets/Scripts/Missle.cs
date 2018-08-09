using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : Photon.MonoBehaviour
{


    public float moveSpeed;
    public float rotateSpeed;
    private Vector3 mousePosition;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        if (photonView.isMine)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        else
        {
            this.enabled = false;
        }
    }


    // In this method we make the missle follow the mouse

    void FixedUpdate()
    {

        Vector2 point2Target = (Vector2)transform.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

     

        float value = Vector3.Cross(point2Target, transform.right).z;

        /*
        if (value > 0) {

                rb.angularVelocity = rotatingSpeed;
        } else if (value < 0)
                rb.angularVelocity = -rotatingSpeed;
        else
                rotatingSpeed = 0;
*/

        rb.angularVelocity = rotateSpeed * value - 90;


        rb.velocity = transform.right * moveSpeed;



    }
}