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
	public bool inLobby;
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
      
		if(PhotonNetwork.room==null){
			if (GUI.Button (new Rect (215, 70, 70, 35), "Join")) {
            PhotonNetwork.JoinOrCreateRoom(roomTextField,new RoomOptions(),TypedLobby.Default);
			}

			if (GUI.Button (new Rect (315, 70, 70, 35), "Create")) {
            PhotonNetwork.CreateRoom(roomTextField, new RoomOptions(), TypedLobby.Default);
        	}

			//Text to Create Room Name
			roomTextField = GUI.TextField (new Rect (200, 125, 200, 20), roomTextField);

			//ScrolView
			// Create table with existing games

				GUILayout.BeginArea(new Rect(Screen.width/3, Screen.height/3, 600,300));
				GUILayout.BeginVertical("Box");
				scrollViewVector = GUILayout.BeginScrollView(scrollViewVector, GUILayout.Width(600), GUILayout.Height(300));

				if(GUILayout.Button("Server 1")){
					Debug.Log("Joining Server 1");
				}

				//Draw Server buttons here!
			foreach(RoomInfo room in PhotonNetwork.GetRoomList()){
				Debug.Log("Game Name: " + room.Name);
				if(GUILayout.Button("Game Name: " + room.Name)){
					InGameGUI.instance.inGame = true;
					PhotonNetwork.JoinRoom (room.Name);

					}
				}

				GUILayout.EndScrollView();
				GUILayout.EndVertical();
				GUILayout.EndArea();

		}
       
		
	}
}
