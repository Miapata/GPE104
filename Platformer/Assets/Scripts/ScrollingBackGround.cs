using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGround : MonoBehaviour {

    //This float is used for the speed
    public float speed;

    //This is the renderer for the material
    public Renderer renderer;

    //This is the offset Vector 
    Vector2 offsetVector;
    // Update is called once per frame
    void Update () {
        //The following code givews us an offset to apply to the material
        //The result is a repeating background
        offsetVector = new Vector2(Time.time * speed,0);
        renderer.material.mainTextureOffset = offsetVector;
	}
}
