using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Intended Use: The following script lets us set the varialbes so that we can use them later on.
//This script is loaded and the statments are executed, and then detroyed after 4 seconds.
//We need the variables below for the canvases so that can disable them since the last level had at least one enabled.

public class Load : MonoBehaviour {

	//Variables :
	// startPoint - This is so that we can have a place to start our player
	// lossScreen - this is the screen that is shown when you go out of bounds
	// victroyScreen - this is shown when you complete a level
	public GameObject startPoint;
	public GameObject lossScreen;
	public GameObject victoryScreen;

	//Execute all of the statements, this gets the level set up
	void Awake () {
		//Find our canvases
		lossScreen=GameObject.Find ("Loss Screen");
		victoryScreen = GameObject.Find ("Victory Screen");

		//Set the GameManager's instance to our startpoint
		GameManager.instance.player.transform.position = startPoint.transform.position;

		//Set both of the screens to false
		lossScreen.SetActive (false);
		victoryScreen.SetActive (false);

		//Destroy this gameobject after 4 seconds
		Destroy (this.gameObject,4);


	}
	
}
