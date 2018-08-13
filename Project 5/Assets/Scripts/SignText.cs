using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SignText : MonoBehaviour {
public GameObject text; // text container

public Vector3 offset; // offest


// Called when collider is detected and it stays
private void OnTriggerStay2D(Collider2D other) {

	// if other is not null
	if(other!=null){

		// check if the tag is player
	if(other.tag=="Player"){

		// set the text container to active
		text.SetActive(true);

		// transform the text to the sign 
		text.transform.position=transform.position+offset;
	}
	}
}

// Called when collider exits trigger
private void OnTriggerExit2D(Collider2D other) {
	
	//If other is null
	if(other!=null){
		//if tag is player
		if(other.tag=="Player"){

			//set activve to false;
			text.SetActive(false);
		}
	}
}
}
