using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Derives from Controller
public class Player : Controller {

    //Declare a NoiseMaker
    public NoiseMaker noiseMaker;
    // Update is called once per frame
    private void Start()
    {
        //Set the noiseMaker
        GameManager.instance.noiseMaker = this.noiseMaker;

        //Volume for the noise maker
        GameManager.instance.noiseMaker.volume = 3;
    }
    void Update () {

        //Move the player, passing in the speed and rotate speed
        MovePlayer(8, 200);
        
	}
}
