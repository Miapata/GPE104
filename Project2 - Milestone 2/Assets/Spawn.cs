using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawn : MonoBehaviour {

	// Use this for initialization
	public GameObject missle,player,canvas,explosion,spawnRing;
	public Transform center;
	bool spawn;


	// Update is called once per frame
	void Update () {
		if (spawn == false) {
			StartCoroutine (spawnObject (Random.Range (1f, 4f)));		
		}

		if (player == null) {
			canvas.SetActive (true);
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
			
	}

	//Used for spawing the Object
	IEnumerator spawnObject(float time){
		spawn = true;
		yield return new WaitForSeconds (time);
		Vector3 spawnPosition = Random.onUnitSphere * (5+5 * 0.5f) + center.position;
		Instantiate (spawnRing,spawnPosition,Quaternion.identity);

		spawn = false;
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject) {
			Instantiate (explosion, other.gameObject.transform.position,Quaternion.identity);
			Destroy (other.gameObject);

		}
	}
}
