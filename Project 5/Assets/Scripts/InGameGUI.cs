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
        if (inGame == false) {
           
			PhotonNetwork.playerName = GUI.TextField (new Rect (300, 80, 200, 35),PhotonNetwork.playerName);
			if (GUI.Button (new Rect (300, 100, 200, 80), "Login")) {
                if (PhotonNetwork.playerName != "")
                {
                    
                    PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity, 0);
                    inGame = true;
                }
			}
		}
	}
}
