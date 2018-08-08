using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour {
    public Animator anim;
    public float speed;
    public SpriteRenderer sr;
	public MonoBehaviour[] scriptsToIgnore;
	// Use this for initialization
	void Start () {
		if (photonView.isMine) {

		} else {
			foreach (var item in scriptsToIgnore) {
				item.enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

        //We gain the horizontal axis and store the float
        float horizontalSpeed = Input.GetAxis("Horizontal");

        //Set our animations Float param to Mathf.Abs(horizontalSpeed)
        anim.SetFloat("Speed", Mathf.Abs(horizontalSpeed));

        //If input is the Left arrow, go ahead and tranform it to the left
        //Wwe also want to flip the x of the sprite renderer
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(-horizontalSpeed * speed * Time.deltaTime,0,0);
            sr.flipX = true;
        }

        //If input is the Rightarrow, go ahead and tranform it to the right
        //Wwe also want maeks sure the flipping is the default
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            transform.position += new Vector3(horizontalSpeed * speed * Time.deltaTime, 0, 0);
        }

        

    }
}
