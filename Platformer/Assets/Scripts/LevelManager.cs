using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public LevelManager instance;

    public GameObject startPosition;
    public GameObject player;
	// Use this for initialization
	void Start () {
        instance = this;
        player = GameManager.instance.player;
        GameManager.instance.checkPoint = startPosition.transform.position;

	}


	
}
