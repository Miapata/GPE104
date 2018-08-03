using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {
	
	//This code is used for GameObjects that you don't want to be destroyed.
	//We also make another gameobject for checking the name of it. If it is
	//either of our canvases, we set it to disabled since the Awake() function
	//has done most of it's job.
	void Awake()
	{
		GameObject go=gameObject;
		DontDestroyOnLoad (gameObject);
		if (go.name == "Victory Screen" || go.name == "Loss Screen") {
			go.SetActive (false);
		}
	}
}
