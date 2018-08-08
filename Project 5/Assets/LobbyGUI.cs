using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LobbyGUI : Photon.MonoBehaviour {

	public string roomTextField="Create Room...";
	public string nameTextField;
	private string playerName;
	private Vector2 scrollViewVector= Vector2.zero;
	private bool playerReady;
	void OnGUI(){

		if (!playerReady) {
			playerName = GUI.TextField (new Rect(200, 125, 300, 80));
			if (GUI.Button (new Rect (215, 70, 70, 35), "Login")) {
				//Check if name is available
			}
		}
		if (playerReady) {
			if (GUI.Button (new Rect (215, 70, 70, 35), "Join")) {
			
			}
			if (GUI.Button (new Rect (315, 70, 70, 35), "Create")) {
				print ("You clicked the button!");
			}

			//Text to Create Room Name
			roomTextField = GUI.TextField (new Rect (200, 125, 200, 20), roomTextField);

			//ScrolView
			scrollViewVector = GUI.BeginScrollView (new Rect (0, 0, 200, 150), scrollViewVector, new Rect (0, 0, 400, 400));

			GUI.EndScrollView ();
		}
	}
}
