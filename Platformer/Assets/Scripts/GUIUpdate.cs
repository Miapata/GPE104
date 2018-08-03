using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// EXPERIMENTAL!
/// This script is used for our stats. It's mainly experimental and will probably be used throughout the whole game.
/// </summary>
public class GUIUpdate : MonoBehaviour {

	//Declare text objects
    public Text triesText;
    public Text timeText;

	//Declare float time
    private float time;
	
	// Update is called once per frame
	void Update () {
		//Set the tries Text to our GameManagers tries
        triesText.text = "Tries: " + GameManager.instance.tries.ToString();

		//Call the add time function
        AddTime();

		//Set the time text to our time, we use special formatting.
        timeText.text = string.Format("Time- {0}", time.ToString("F2"));
	}

	//Method for adding to our time to show the player how in what
	// time they completed the level.
    void AddTime()
    {
        time += Time.deltaTime;
    }
}
