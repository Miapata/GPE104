using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PhotonManager : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("2");
	}

	void OnJoinedLobby(){
		
	}

	void OnJoinedRoom(){
        SceneManager.LoadSceneAsync(1);
	}
    void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
       
    }

}
