using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public Transform center;
    public GameObject meteor, enemyShip,explosion;
    public GameObject[] enemies = new GameObject[2];
    int index;
    public float timeA,timeB;
    public bool spawnIt=true;
    public List<GameObject> enemyList;
    public List<GameObject> spawns;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
            for (int i = enemyList.Count; i < 3; i++)
            {
            if (spawnIt == true)
            {
                StartCoroutine(SpawnObject(timeA, timeB));
            }
            }

        foreach (GameObject enemy in enemyList)
        {
            //If enemy is no longer existing
            if (enemy == null)
            {
                //Remove from list
                enemyList.Remove(enemy);
            }
        }


    }

    IEnumerator SpawnObject(float timeA,float timeB)
    {
        spawnIt = false;
        yield return new WaitForSeconds(Random.Range(timeA, timeB));
        Vector3 spawnPosition = Random.onUnitSphere * (5 + 5 * 0.5f) + center.position;
        index = Random.Range(0, enemies.Length);
        enemyList.Add(Instantiate(enemies[index], spawnPosition, Quaternion.identity));
        spawnIt = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
