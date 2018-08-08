using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonManager : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("2");
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinOrCreateRoom ("Room",new RoomOptions() { MaxPlayers=4}, TypedLobby.Default);
	}

	void OnJoinedRoom(){
		PhotonNetwork.Instantiate ("Player",transform.position,Quaternion.identity,0);
	}
    void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
       
    }

}
