using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour {
    public Animator anim;
    public float speed;
    public float fireRate;
    public bool canFire;
    public SpriteRenderer sr;
    public List<GameObject> missiles;
	
	// Update is called once per frame
	void Update () {

        //We gain the horizontal axis and store the float
        float horizontalSpeed = Input.GetAxis("Horizontal");

        //Set our animations Float param to Mathf.Abs(horizontalSpeed)
        anim.SetFloat("Speed", Mathf.Abs(horizontalSpeed));

        //If input is the Left arrow, go ahead and tranform it to the left
        //Wwe also want to flip the x 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(-horizontalSpeed * speed * Time.deltaTime,0,0);
            transform.localScale = new Vector3(-1, 1, 0);
        }

        //If input is the Rightarrow, go ahead and tranform it to the right
        //Wwe also want make sure the flipping is the default
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 0);

            transform.position += new Vector3(horizontalSpeed * speed * Time.deltaTime, 0, 0);
        }

        //If input is Space key, go ahead and Instantiate a missle
        if (Input.GetKey(KeyCode.Space))
        {
            if (missiles.Count < 3)
            {
                if (canFire == true)
                {
                    StartCoroutine("Fire", fireRate);
                }
            }
        }

        foreach (GameObject missile in missiles)
        {
            if (missile == null)
            {
                missiles.Remove(missile);
            }
        }

    }

    IEnumerator Fire(float fireRate)
    {
  
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
        GameObject missile=PhotonNetwork.Instantiate("Missile", transform.position + transform.up*2, Quaternion.identity, 0);
        missiles.Add(missile);
    }
}
