using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	/// <summary>
	/// This script is used for just one Level. We need every level to have one so that
	/// it can be easier to manage the player and stat position. The GameManager's checkpoint is set
	/// to the level's startPoint
	/// </summary>

	// We need to first declare an instance
    public static LevelManager instance;


	//The gameobjects are declared for later use
    public GameObject startPosition;
    public GameObject player;

	// Use this for initialization
	void Start () {
		//Set our declared instance to this 
        instance = this;

		//Find the player
		player = GameObject.Find("Player");

		//Set the checkpoint to this levels start position
        GameManager.instance.checkPoint = startPosition.transform.position;

	}


	
}
