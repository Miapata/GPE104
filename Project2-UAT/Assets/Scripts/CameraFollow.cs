using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variables
    float smoothSpeed;
    Vector3 velocity = Vector3.zero;
    // Use this for initialization


    // Update is called once per frame
    void LateUpdate()
    {
		//If target is not null
		if (GameManager.instance.player)
        {
			//point Vector that is converted to viewport space
			Vector3 point = Camera.main.WorldToViewportPoint(GameManager.instance.player.transform.position);
			//delta vector that is converted to world space
			Vector3 delta = GameManager.instance.player.transform.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));

			//destination FROM A TO B
            Vector3 destination = transform.position + delta;

			//Smooth transition from current position to destination
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, 0.2f);
        }
    }
}
