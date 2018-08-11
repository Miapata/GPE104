using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour {
    public Animator anim;
    public float speed;
    public float fireRate;
    public bool canFire;
	public int maxMissiles;
    public SpriteRenderer sr;
    public List<GameObject> missiles;
	public PhotonView[] photonViews;
	public int timesCanJump;
	public Rigidbody2D rigidBod2D;
	public float jumpForce;
	public bool isGrounded;
	int timesJumped;
	// Update is called once per frame
	void Update () {

        //We gain the horizontal axis and store the float
        float horizontalSpeed = Input.GetAxis("Horizontal");

        //Set our animations Float param to Mathf.Abs(horizontalSpeed)
        anim.SetFloat("Speed", Mathf.Abs(horizontalSpeed));

        //If input is the Left arrow, go ahead and tranform it to the left
        //Wwe also want to flip the x 
		if (Input.GetButton("Left"))
        {
            transform.position -= new Vector3(-horizontalSpeed * speed * Time.deltaTime,0,0);
            transform.localScale = new Vector3(-1, 1, 0);
        }

        //If input is the Rightarrow, go ahead and tranform it to the right
        //Wwe also want make sure the flipping is the default
		if (Input.GetButton("Right"))
        {
            transform.localScale = new Vector3(1, 1, 0);

            transform.position += new Vector3(horizontalSpeed * speed * Time.deltaTime, 0, 0);
        }

        // If input is Space key, go ahead and Instantiate a missle
		// Important: The maxMissile variable determines how many we can spawn
		// The Coroutine is used to Fire the missile with a set fireRate.
        if (Input.GetKey(KeyCode.Space))
        {
            if (missiles.Count < maxMissiles)
            {
                if (canFire == true)
                {
                    StartCoroutine("Fire", fireRate);
                }
            }
        }

		if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W)) {
			if (timesJumped < timesCanJump) {
				Vector2 temp = rigidBod2D.velocity;

				if (rigidBod2D.velocity.y < 0 ){
					temp.y = 0;
					rigidBod2D.velocity = temp;
				}
				timesJumped++;
				rigidBod2D.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
			}
		}

        foreach (GameObject missile in missiles)
        {
            if (missile == null)
            {
                missiles.Remove(missile);
            } else {
				
				photonViews = missile.GetPhotonViewsInChildren ();
				foreach (PhotonView view in photonViews) {
					view.TransferOwnership (photonView.owner);
				}
			}
        }

    }

	//Method used for Firing the missiles.
	// There is a fire rate that can be used to control how fast the firing is.
	// If the list is equal to the max amount of missiles, no more can spawn.
    IEnumerator Fire(float fireRate)
    {
  
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
		GameObject missile=PhotonNetwork.Instantiate("Missile", transform.position + transform.up*2, Quaternion.identity, 0);
		missile.transform.parent = gameObject.transform;
        missiles.Add(missile);
    }

	// In this method, we are saying that On Collision with the floor,
	// set the player's isGrounded state to true and timesJumped back to 0
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag=="Floor") {
			isGrounded = true;
			timesJumped = 0;
		}
	}

	// In this method, it simply states that since the player has left the ground, we are now in the air
	// which sets isGrounded to false.
	void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.tag=="Floor") {
			isGrounded = false;
		
		}
	}
}

