using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //Declare instance
    public static GameManager instance;

    //lives
    public int lives;
    
    //Floats
    public float chance, enemy_player_RotateSpeed, player_MoveSpeed, laserSpeed,player_player_RotateSpeed,time,enemy_Speed;
    void Awake()
    {
        // As long as there is not an instance already set
        if (instance == null)
        {
            instance = this; // Store THIS instance of the class (component) in the instance variable
            DontDestroyOnLoad(gameObject); // Don't delete this object if we load a new scene
        }
        else
        {
            Destroy(this.gameObject); // There can only be one - this new object must die
            Debug.Log("Warning: A second game manager was detected and destroyed.");
        }
    }
}

