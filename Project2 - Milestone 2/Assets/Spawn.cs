using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawn : MonoBehaviour {

	// Use this for initialization

	//All of the gameobjects
	public GameObject missle,player,canvas,explosion,spawnRing;

	//Transform
	public Transform center;

    //Vector2
    public Vector2 centerVec;

	//Bool for spawning
	bool spawn;


	// Update is called once per frame
	void Update () {

		//If spawn is false
		if (spawn == false) {

			//Start coroutine for spawing
			StartCoroutine (spawnObject (Random.Range (1f, 4f)));		
		}

		//If player is null
		if (player == null) {
			
			//Set canvas gameobject active
			canvas.SetActive (true);

			//If R is down
			if (Input.GetKeyDown (KeyCode.R)) {

				//Load scene
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
			
	}

	//Used for spawing the Object
	IEnumerator spawnObject(float time){

		//Set spawn to true
		spawn = true;

		//wait for a random time
		yield return new WaitForSeconds (time);

        //spawn in a random radius
        Vector3 spawnPosition = Random.insideUnitCircle * (5 + 5 * 0.5f) + centerVec;

		//Instantiate the ring
		Instantiate (spawnRing,spawnPosition,Quaternion.identity);

		//spawn is false
		spawn = false;
	}

	//TriggerExit2D method
	void OnTriggerExit2D(Collider2D other){
		//If any gameobject leaves the trigger
		if (other.gameObject) {
			
			//Spawn the explosion
			Instantiate (explosion, other.gameObject.transform.position,Quaternion.identity);

			//Destry gameobject
			Destroy (other.gameObject);

		}
	}
}
