using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIUpdate : MonoBehaviour {

    public Text triesText;
    public Text timeText;
    private float time;
	
	// Update is called once per frame
	void Update () {
        triesText.text = "Tries: " + GameManager.instance.tries.ToString();
        timeText.text = "Time:" + time + Time.deltaTime.ToString();
	}
}
