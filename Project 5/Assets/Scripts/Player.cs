using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {

    public Animator anim; // animator
	public GameObject menuCanvas; // menu
	public Text text; // canvas text
	public Image progressBar; // progress bar
    public float speed; // speed of the player
    public float fireRate; // rate of fire
	public GameObject missileGameObject; // player
	public float scaling; // scaling of the player
    public bool canFire; // can the player
	public int maxMissiles; // max missiles player can fire
    public SpriteRenderer sr; // sprite renderer
    public List<GameObject> missiles; // list of missiles
	public List<GameObject> spawnPointList; // list of spawnpoints
	public int timesCanJump; // times the player can jump
	public Rigidbody2D rigidBod2D; // rigidBody2D
	public float jumpForce; // jump strength
	public bool isGrounded; // check if the player is grounded
	public bool finished; // is finished
	public AudioClip jumpSound; // jump sound
	private float time; // time
	int timesJumped; // times jumped

	// Update is called once per frame
	void Update () {

        // We gain the horizontal axis and store the float
        float horizontalSpeed = Input.GetAxis("Horizontal");

        // Set our animations Float param to Mathf.Abs(horizontalSpeed)
        anim.SetFloat("Speed", Mathf.Abs(horizontalSpeed));

        // If input is the Left arrow or A key, go ahead and tranform it to the left
		// We also want make sure the scale is negative
		if (Input.GetButton("Left"))
        {
			
			// change the scale to negative
            transform.localScale = new Vector3(scaling*-1, transform.localScale.y, 0);

			// transform our player to the left 
            transform.position -= new Vector3(-horizontalSpeed * speed * Time.deltaTime,0,0);
        }

        // If input is the Right Arrow or D key go ahead and tranform it to the right
		// We also want make sure the scale is the default
		if (Input.GetButton("Right"))
        {
			
			// change the scale to positive
            transform.localScale = new Vector3(-scaling*-1, transform.localScale.y, 0);

			// transform our player to the right
            transform.position += new Vector3(horizontalSpeed * speed * Time.deltaTime, 0, 0);
        }

        // If input is Space key, go ahead and Instantiate a missle
		// Important: The maxMissile variable determines how many we can spawn
		// The Coroutine is used to Fire the missile with a set fireRate.
        if (Input.GetKey(KeyCode.Space))
        {
			// If the missiles count is less than the max missiles we can spawn
            if (missiles.Count < maxMissiles)
            {
				// check if we can Fire
                if (canFire == true)
                {
					// If we are able to fire, start Fire Coroutine
                    StartCoroutine("Fire", fireRate);
                }
            }
        }

		// If our inputs are UpArrow or the W key, we want to check if we can jump
		if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W)) {

			// Check if the times that we jumped are less than the times that can jump
			if (timesJumped < timesCanJump) {

				// create a temp variable for our Rigidbody2D's velocity
				Vector2 temp = rigidBod2D.velocity;

				// If our player's y velocity is less than 0
				if (rigidBod2D.velocity.y < 0 ){
					
					// set the temp Rigidbody2D velocity to 0
					temp.y = 0;
					// set our real Rigidbody2D to the temp variable
					rigidBod2D.velocity = temp;
				}

				// Increase the times Jumped
				timesJumped++;

				// we are now jumping, let the animator know
				anim.SetBool ("isJumping", true);

				// we are no longer falling, let the animator know
				anim.SetBool ("isFalling", false);

				// Add Impulse force to the RigidBody2D of our player
				rigidBod2D.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
				
				// Play jump sound
				AudioSource.PlayClipAtPoint(jumpSound,transform.position);
			}
		}
	// If the P key is pressed
	if(Input.GetKeyDown(KeyCode.P)){

		// Reset position
transform.position= new Vector3(0,-1.97f,0);
	
	}


		// If th escape key is pressed
		if(Input.GetKeyDown(KeyCode.Escape)){
			// Quit the application
			Application.Quit();
		}

// We check if finished is false
if(finished==false){
	// Increase time
time+=Time.deltaTime;

// Update the text
	text.text="Time:"+time.ToString("0.00");
}

// Check the fillamount. If it is full, player won the game
if(progressBar.fillAmount==1){
	// finished is true
	finished=true;

	// Enable the menu
	menuCanvas.SetActive(true);
}

		// We iterate through each missile to see if there are any that 
		// have been destroyed.

        foreach (GameObject missile in missiles.ToArray())
        {

			// If the missile is null
            if (missile == null)
            {
				// Remove it form the list
                missiles.Remove(missile);

            } 
        }

		// If the player's Rigidbody2D's velocity is less than 0
		if (rigidBod2D.velocity.y < 0) {

			// Let our animator know we are falling
			anim.SetBool ("isFalling", true);

			// Let the animator also know that we are no longer jumping
			anim.SetBool ("isJumping", false);
		}

    }

	// Method used for Firing the missiles.
	// There is a fire rate that can be used to control how fast the firing is.
	// If the list is equal to the max amount of missiles, no more can spawn.
    IEnumerator Fire(float fireRate)
    {
  		// set canFire to false
        canFire = false;

		// wait to fire
        yield return new WaitForSeconds(fireRate);

		// canFire is now true
        canFire = true;

		// Fire a missle, we use Instantiate
		GameObject missile=Instantiate(missileGameObject, transform.position + transform.up*2, Quaternion.identity);

		// Set the missile's parent to the player who instantaited it
		missile.transform.parent = gameObject.transform;

		// Add the missile to the missiles list
        missiles.Add(missile);
    }

	// In this method, we are saying that On Collision with the floor,
	// set the player's isGrounded state to true and timesJumped back to 0
	void OnCollisionEnter2D(Collision2D collision){

		// If we hit the floor
		if (collision.gameObject.tag=="Floor") {
			
			// set our animator's isJumping bool to false
			anim.SetBool ("isJumping", false);
			// set our animator's isFalling bool to false
			anim.SetBool ("isFalling", false);

			// set is grounded to true
			isGrounded = true;

			// reset times jumped
			timesJumped = 0;
		}
	}

	// In this method, it simply states that since the player has left the ground, we are now in the air
	// which sets isGrounded to false.
	void OnCollisionExit2D(Collision2D collision){

		// If the collision exited is the floor
		if (collision.gameObject.tag=="Floor") {
			
			// we are no longer grounded
			isGrounded = false;

		}
	}

	// On collision stay , we want to increase the players progress if
	// the collider is the enemy
	private void OnCollisionStay2D(Collision2D other) {
		if(other.collider.tag=="Enemy"){
			progressBar.fillAmount+=0.02f;
		}
	}


}

