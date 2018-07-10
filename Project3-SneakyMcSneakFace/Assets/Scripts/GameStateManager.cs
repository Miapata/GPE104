using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStateManager : MonoBehaviour {
    public static GameStateManager instance;
    public enum States
    {
        Start,
        GamePlay,
        GameOver
    }

    public States states;
    public GameObject gameOver;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        switch (states)
        {
            case States.Start:
                if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
                {
                    
                    SceneManager.LoadScene(0);
                }
                break;

            case States.GamePlay:
                if (gameOver == null)
                {
                    gameOver = Instantiate(GameManager.instance.gameOverCanvas);
                    gameOver.SetActive(false);
                    gameOver.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(LoadGamePlay);
                    gameOver.GetComponent<GameOver>().gameObjects[0] = GameObject.FindGameObjectWithTag("Destroy");
                }

                break;

            case States.GameOver:
               
                gameOver.SetActive(true);
                break;
        }
    }

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

    public void LoadGamePlay()
    {
        instance.states = GameStateManager.States.GamePlay;
        SceneManager.LoadScene(1);
        if (gameOver != null)
        {
            gameOver.SetActive(false);
        }
    }

    
}
