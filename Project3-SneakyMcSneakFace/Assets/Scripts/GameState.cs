using UnityEngine;
using UnityEngine.SceneManagement;
public class GameState : MonoBehaviour {

    public static GameState instance;

    public GameStates currentGameState;
   
    public GameObject gameOverCanvas;
    
    public enum GameStates
    {
        Start,
        Game,
        GameOver
    }
       //Used for the button
	public void StartGame()
    {
        DontDestroyOnLoad(this);
        currentGameState = GameStates.Game;
        //Load the next scene
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        switch (currentGameState)
        {
            case GameStates.Start:
                if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
                {
                    currentGameState = GameStates.Game;
                    SceneManager.LoadScene(0);
                }
                break;

            case GameStates.Game:
                //Jesus Christ
                if (GameManager.instance.player == null)
                {
                    GameManager.instance.player = GameObject.FindGameObjectWithTag("Player");
                }
               
                break;

            case GameStates.GameOver:
                
                if (GameManager.instance.gameOverCanvas.activeInHierarchy == false)
                {
                    GameManager.instance.gameOverCanvas.SetActive(true);
                }
                break;

        }
    }

    

}
