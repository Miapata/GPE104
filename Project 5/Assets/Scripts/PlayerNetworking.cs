using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworking : Photon.MonoBehaviour {

    public MonoBehaviour[] scriptsToIgnore;
    public GameObject mainCam;
    private PhotonView photonView;
    // Use this for initialization
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.isMine)
        {
			
        }
        else
        {
            mainCam.SetActive(false);
            foreach (var item in scriptsToIgnore)
            {
                item.enabled = false;
            }
        }
    }

    // Update is called once per frame
  
  

}
