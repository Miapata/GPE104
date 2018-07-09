using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Derives from Controller
public class Player : Controller {

	
	// Update is called once per frame
	void Update () {

        //Move the player, passing in the speed, and rotate speed
        MovePlayer(8, 200);
        
	}
}
