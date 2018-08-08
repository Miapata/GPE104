using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LobbyGUI : Photon.MonoBehaviour {
    public static LobbyGUI instance;

	public string roomTextField="Create Room...";
	public string nameTextField;
    public string nameUnav;
    public string nameAv;
    public static List<string> playerList;

    public List<Room> roomList;

	private string playerName;
	private Vector2 scrollViewVector= Vector2.zero;

    [SerializeField]
	private bool playerReady;
    [SerializeField]
    private bool nameAvailable;


    private void Start()
    {
        instance = this;
    }

    void OnGUI(){
      
		
			if (GUI.Button (new Rect (215, 70, 70, 35), "Join")) {
            PhotonNetwork.JoinOrCreateRoom(roomTextField,new RoomOptions(),TypedLobby.Default);
			}

			if (GUI.Button (new Rect (315, 70, 70, 35), "Create")) {
            PhotonNetwork.CreateRoom(roomTextField, new RoomOptions(), TypedLobby.Default);
        }

			//Text to Create Room Name
			roomTextField = GUI.TextField (new Rect (200, 125, 200, 20), roomTextField);

			//ScrolView
			
        foreach (RoomInfo room in PhotonNetwork.GetRoomList())
        {
            if (GUILayout.Button(room.Name.ToString()))
            {
                PhotonNetwork.JoinRoom(room.Name);
            }
        }
       
		
	}
}
