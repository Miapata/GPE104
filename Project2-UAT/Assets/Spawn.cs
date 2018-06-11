using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public Transform center;
    public GameObject meteor, enemyShip;
    List<GameObject> enemyList;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 spawnPosition = Random.onUnitSphere * (5 + 5 * 0.5f) + center.position;
        for (int i = enemyList.Count; i < 3; i++)
        {
            enemyList.Add(Instantiate())
        }
        
    }
}
