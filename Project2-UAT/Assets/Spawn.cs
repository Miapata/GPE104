using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform center;
    public GameObject meteor, enemyShip, explosion;
    public GameObject[] meteors;
    int index;
    public float timeA, timeB, chance;
    public bool spawnIt = true;
    public List<GameObject> enemyList;
    public List<GameObject> spawns;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = enemyList.Count; i < 3; i++)
        {
            if (spawnIt == true)
            {
                StartCoroutine(SpawnObject(timeA, timeB));
            }
        }
        try
        {
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
        catch (System.Exception myExc)
        {

        }


    }

    IEnumerator SpawnObject(float timeA, float timeB)
    {
        spawnIt = false;
        yield return new WaitForSeconds(Random.Range(timeA, timeB));


        if (Random.value < chance)
        {
            enemyList.Add(Instantiate(enemyShip, spawns[Random.Range(0,spawns.Count)].transform.position, Quaternion.identity));
        }
        else
        {
            enemyList.Add(Instantiate(meteors[Random.Range(0,meteors.Length)], spawns[Random.Range(0, spawns.Count)].transform.position, Quaternion.identity));
        }
        spawnIt = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Object")
        {

            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);

        }
    }
}
