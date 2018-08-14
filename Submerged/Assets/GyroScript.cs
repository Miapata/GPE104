using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroScript : MonoBehaviour {
   private  Gyroscope gyro;
private bool Gyroenabled;

    private GameObject cameraContainer;
    private Quaternion rot;

    public void Start()
    {
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);
        Gyroenabled = EnableGyro();
    }

    public bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90, 90, 0);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }

        return false;
    }

    public void Update()
    {
        if (Gyroenabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }

        
    }

}
