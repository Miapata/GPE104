using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : Photon.MonoBehaviour
{


    public float moveSpeed;
    public float rotatingSpeed;
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


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition),0.2f);

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z-90);
    }

    private void FixedUpdate()
    {
        rb.angularVelocity = rotatingSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }

}
