using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is called when the player completes the level by stepping into our Goal
/// gameobject.
/// </summary>
public class LevelComplete:MonoBehaviour  {

	//Declare a particle system
    public ParticleSystem ps;

	//Declare a canvas (victoryCanvas)
    public GameObject canvas;

	//Initialize
	public void Start(){
		//set the canvas to the GameManager's canvas
		canvas = GameManager.instance.victoryCanvas;
	}

	//When the player enters the trigger of our Goal Gameobject this is called.
    public void OnTriggerEnter2D(Collider2D collision)
    {

		//Check if the tag is player
        if (collision.tag == "Player")
        {
			//Play the particleSystem
            ps.Play();

			//Set the level Complete canvas to true
            canvas.SetActive(true);
        }
    }

}
