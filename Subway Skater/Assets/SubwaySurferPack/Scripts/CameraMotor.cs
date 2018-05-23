using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	public Transform lookAt;
	public Vector3 offset = new Vector3 (0, 5.0f, -10.0f);

    void Start()
    {
        
    }

	private void LateUpdate(){
        Vector3 desiredPoistion = lookAt.position + offset;
        desiredPoistion.x = 0;
        transform.position = Vector3.Lerp(transform.position, desiredPoistion, Time.deltaTime);
	}
}
