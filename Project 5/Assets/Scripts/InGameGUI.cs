using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameGUI : Photon.MonoBehaviour {
	public static InGameGUI instance;
	public bool inGame;

	public void Start(){
		instance = this;
	}

	void OnGUI(){
		if (inGame==true) {

			PhotonNetwork.playerName = GUI.TextField (new Rect (100, 300, 200, 35),PhotonNetwork.playerName);
			if (GUI.Button (new Rect (300, 100, 35, 80), "Login")) {
				PhotonNetwork.Instantiate ("Player", transform.position, Quaternion.identity, 0);
			}
		}
	}
}
