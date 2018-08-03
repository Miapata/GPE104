using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {

    //The following methods are used for the buttons to load levels.

	//These are used below
    public GameObject player;
    public GameObject lostCanvas;
	public GameObject victory_Canvas;

	//Disable our victory screen whenever we load a new level
	void DisableVictoryScreen(){
		victory_Canvas.SetActive (false);
	}

	//Change our level
	//We increase the scene int by adding one to it
	public void ChangeLevel(){
		int scene = SceneManager.GetActiveScene ().buildIndex;
		scene++;
		SceneManager.LoadScene (scene);

		//Disable the Victoy canvas
		DisableVictoryScreen ();
	}


	//Used to respawn our player
    public void Respawn()
    {
		//Enable our player so that we can play again
        player.SetActive(true);

		//Disable the lost Canvas 
        lostCanvas.SetActive(false);
    }
}
