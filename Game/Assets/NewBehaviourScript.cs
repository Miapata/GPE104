using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public GameObject[] characters = new GameObject[2];
	public int index;
	public GameObject cube;
	public bool isBeingHandled;
	// Use this for initialization
	void Start () {
		characters [0] = GameObject.Find ("Barbarian");
		characters [1] = GameObject.Find ("Grunt");
		characters [2] = GameObject.Find ("Skeleton");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Left(){
		if (index >= 0) {
			index--;
		} else {
			
		}
		characters [index].SetActive (true);
		characters [index + 1].SetActive (false);
	}

	public void Right(){
		if (index <= 3) {
			index++;
		} else {

		}
		characters [index].SetActive (true);
		characters [index - 1].SetActive (false);

	}


}
