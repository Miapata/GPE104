using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVairalbesToNull : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.instance.checkPoint = Vector3.zero;	
	}
	
}
