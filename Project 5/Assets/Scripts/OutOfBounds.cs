using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OutOfBounds : MonoBehaviour {

// On collision enter, check the tag
private void OnCollisionEnter2D(Collision2D other) {

	// Check the tag
	if(other.gameObject.tag=="Player"){

		// Destroy player
		GameObject.Destroy(other.gameObject);
		// Reset the game
		Reset();
	}
}

// Reset
public void Reset(){

	// Load the level 
SceneManager.LoadScene(0);
}
}
