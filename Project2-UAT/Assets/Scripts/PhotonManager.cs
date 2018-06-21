using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PhotonManager : MonoBehaviour {
    public static PhotonManager instance;
    public RoomInfo[] rooms;
	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

      
        PhotonNetwork.ConnectUsingSettings("0.1");
      
        PhotonNetwork.JoinLobby(TypedLobby.Default);

        //Load the scene 
        PhotonNetwork.LoadLevel(1);


        print(rooms.Length.ToString());

    }
     void OnConectedToMaster()
    {

    }
    void OnJoinedLobby()
    {
   
        
        
    }

  

  
       


}
