using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position+= new Vector3(0,10*Time.deltaTime,0);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += new Vector3 (0, -10 * Time.deltaTime, 0);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.eulerAngles += new Vector3 (0, 0, 20 * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (0,0,20*Time.deltaTime);
		}
	}
}
