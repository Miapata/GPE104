using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public LevelManager instance;

    public GameObject startPosition;

	// Use this for initialization
	void Start () {
        instance = this;

        GameManager.instance.checkPoint = startPosition.transform.position;
	}
	
}
