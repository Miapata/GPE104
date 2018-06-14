using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameManager gameManager;

    //Transform center
    public Transform center;
    
    //Public gameobjects
    public GameObject meteor, enemyShip, explosion,player;


    //Public floats
    public float timeA, timeB, chance;

    //bool used for spawing
    public bool spawnIt = true;



    //The player script
    public PlayerMove playerScript;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //If i is less than enemy count
        for (int i = GameManager.instance.enemyList.Count; i < 3; i++)
        {
            //Check if spawnIt is true
            if (spawnIt == true)
            {
                //Start Coroutine to spawn enemy
                StartCoroutine(SpawnObject(timeA, timeB));
            }
        }

        //Used for exceptions
        try
        {

            //For each enemy in enemy list
			foreach (GameObject enemy in GameManager.instance.enemyList)
            {

                //If enemy is no longer existing
                if (enemy == null)
                {

                    //Remove from list
                    GameManager.instance.enemyList.Remove(enemy);
                }
            }
        }

        //Catch an exception
        catch (System.Exception myExc)
        {

        }


    }

    //Used for Coroutine
    IEnumerator SpawnObject(float timeA, float timeB)
    {

        //Spawn it is false
        spawnIt = false;

        //Wait for a random range
        yield return new WaitForSeconds(Random.Range(timeA, timeB));

        //Chance for enemy ship to spawn
        if (Random.value < GameManager.instance.chance)
        {
            //Instantiate the ship a random spawn point
			GameManager.instance.enemyList.Add(Instantiate(enemyShip, GameManager.instance.spawns[Random.Range(0, GameManager.instance.spawns.Count)].transform.position, Quaternion.identity));
        }

        //Else if
        else
        {
            //Instantiate meteor
			GameManager.instance.enemyList.Add(Instantiate(GameManager.instance.meteors[Random.Range(0, GameManager.instance.meteors.Length)], GameManager.instance.spawns[Random.Range(0, GameManager.instance.spawns.Count)].transform.position, Quaternion.identity));
        }

        //Spawn is true
        spawnIt = true;
    }


    //Used to detect exit of collider
    void OnTriggerExit2D(Collider2D collision)
    {
        //If the tag is a object
        if (collision.tag == "Object") 
        {
            //Instantiate explosion
            Instantiate(explosion, collision.transform.position, Quaternion.identity);

            //Destroy it
            Destroy(collision.gameObject);

        }

        //If the tag is the Player tag
        if (collision.tag=="Player")
        {

            //subtract the amount of lives
			GameManager.instance.lives--;

            //Check if player lives is 0
			if (GameManager.instance.lives == 0)
            {

                //Quit the game
                Application.Quit();
            }

            //Instantiate the explosion
            Instantiate(explosion, collision.transform.position, Quaternion.identity);

            //Destroy player
            Destroy(collision.gameObject);

            //instaniate new player
            Instantiate(player, center);
        }
    }

 
}
