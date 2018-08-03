using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script Use: This script is used to check if the player is out of bounds
/// it is basic and self explained. 
/// </summary>
public class OutOfBounds : MonoBehaviour {
	//These variables are for declaring the player, loss canvas
	// and the rigidBody.
	//
	//The offset is used when the out of bounds GameObject is followinf our player.
    public GameObject lossCanvas;
	public GameObject player;
	public Rigidbody2D rigidBody;
	public Vector3 offset;

	//Zero velocity
    Vector2 zeroV;

	//Set the player to the GameManager's player
	public void Start(){
		player=GameManager.instance.player;
	}

	//If the player enters the triggerArea then we simulate the player being executed.
    private void OnTriggerEnter2D(Collider2D collision)
	{
		//Check if the colider's tag name is player
        if (collision.tag == "Player")
        {
			//Increase the amount of tries (EXPERIMENTAL)
   	         GameManager.instance.tries++;

			//The player position is equal to the checkpoint that was reached.
            player.transform.position = GameManager.instance.checkPoint;

			//Set the player to false 
            player.SetActive(false);

			//Set the loss canvas to enabled so that we can respawn
            lossCanvas.SetActive(true);
            rigidBody.velocity = zeroV ;
        }
    }

	//The following code tells the OutOfBounds Gameobject to follow the player at a given offset
	private void LateUpdate(){
		transform.position = player.transform.position + offset;
	}


}
