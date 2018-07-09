using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Derives from Controller
public class Player : Controller {

    public NoiseMaker noiseMaker;
    // Update is called once per frame
    private void Start()
    {
        noiseMaker.volume = 10;
    }
    void Update () {

        //Move the player, passing in the speed, and rotate speed
        MovePlayer(8, 200);
        
	}
}
