using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworking : MonoBehaviour {

    public MonoBehaviour[] scriptsToIgnore;

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
            foreach (var item in scriptsToIgnore)
            {
                item.enabled = false;
            }
        }
    }

    // Update is called once per frame
  
  

}
