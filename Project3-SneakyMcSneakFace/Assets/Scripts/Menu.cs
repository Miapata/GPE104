using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

       //Used for the button
	public void StartGame()
    {

        //Load the next scene
        SceneManager.LoadScene(1);
    }
}
