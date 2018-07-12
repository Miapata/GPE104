using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStateManager : MonoBehaviour {
    public static GameStateManager instance;

	//This an enum that defines the states
    public enum States
    {


        Start,
        GamePlay,
        GameOver
    }

	//create a public state
    public States states;


    public GameObject gameOver;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

		//Loop through the states for the state machine
        switch (states)
        {

		//If case is Start
            case States.Start:

			//Check if the active scene !=  to the Start scene
                if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
                {
				//Load the start scene
                    SceneManager.LoadScene(0);
                }
                break;


			//If the case is GamePLay state
            case States.GamePlay:

			//If the game over canvas is not equal to null
                if (gameOver == null)
                {

				//gameOver is equal to a new gameobject
                    gameOver = Instantiate(GameManager.instance.gameOverCanvas);

				//Gameobject.s active is false now
                    gameOver.SetActive(false);

				//Add a listener to the button located in the gameOver object
                    gameOver.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(LoadGamePlay);

				//Set index 0 equal to the GameoObject with the Destroy tag on it
                    gameOver.GetComponent<GameOver>().gameObjects[0] = GameObject.FindGameObjectWithTag("Destroy");
                }

                break;
			//If the game is over
            case States.GameOver:
               

			//Set the gameobject canvas to true
                gameOver.SetActive(true);
                break;
        }
    }


	//Singleton pattern
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        
    }


	//Function for the button to Start Game
    public void LoadGamePlay()
    {

		//Set the state to Game PLay
        instance.states = GameStateManager.States.GamePlay;

		//Load the game scene
        SceneManager.LoadScene(1);

		//If the gameOver object is not null
        if (gameOver != null)
        {
			//Set Active to false
            gameOver.SetActive(false);
        }
    }

    
}
