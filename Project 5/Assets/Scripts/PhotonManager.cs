using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonManager : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("1.0");
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinOrCreateRoom ("Room",new RoomOptions(), TypedLobby.Default);
	}

	void OnJoinedRoom(){
		PhotonNetwork.Instantiate ("Player",transform.position,Quaternion.identity,0);
	}

}
