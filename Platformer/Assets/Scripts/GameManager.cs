using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The is our game manager and contains very important variables.
/// Make sure that this is well documented.
/// </summary>
public class GameManager : MonoBehaviour {
	//Declare an instance
    public static GameManager instance;

	//The variables are used for the game so that other scripts can easily refernce them.
	public GameObject victoryCanvas;
    public Vector3 checkPoint;
    public GameObject player;
	public Rigidbody2D playerRB;
    public int tries;

 	//This is the singleton pattern. Basically it gives us one isntance. 
	//Important since we dont want more than one.
	void Awake () {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
	}

}
