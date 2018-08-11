using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateName : Photon.MonoBehaviour {
	public Text text;
	public Vector3 offset;
	public GameObject player;
	// Use this for initialization
	void Start () {
		
		text.text = photonView.owner.NickName;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position+offset;
	}
}
