using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {

    //The following methods are used for the buttons to lad levels.
    //Add more if you need more levels.

    public GameObject player;
    public GameObject lostCanvas;

  

    public void FirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void SecondLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void ThirdLevel()
    {
        SceneManager.LoadScene(3);
    }

    public void Respawn()
    {
        player.SetActive(true);
        lostCanvas.SetActive(false);
    }
}
