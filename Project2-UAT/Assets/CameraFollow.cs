using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    float smoothSpeed;
    Vector3 velocity = Vector3.zero;
    // Use this for initialization


    // Update is called once per frame
    void LateUpdate()
    {
        if (player)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(player.transform.position);
            Vector3 delta = player.transform.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 0.2f);
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
