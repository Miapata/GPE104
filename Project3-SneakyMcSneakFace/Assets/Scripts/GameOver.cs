using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    public int gameOver;
    public GameObject[] gameObjects;


    // Use this for initialization
    private void Awake()
    {
        GameManager.instance.gameOverCanvas = gameObject;
        DontDestroyOnLoad(this.gameObject);
    }
    void OnEnable()
    {
           
            Debug.Log("Game Over");
            foreach (GameObject item in gameObjects)
            {
                Destroy(item);
            }
        }
        
    }

   

