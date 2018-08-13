using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateName : Photon.MonoBehaviour {
	public Text text; // player name text
	public Vector3 offset; // offset for position
	public GameObject enemy; // player gameobject

public void Update(){
	// Set the text to the enemy's position and add the offset
	text.transform.position=enemy.transform.position+offset;
}
}
