using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Intended Use: This script is what defines the player's mechanics. The player's movement and jump.
// There are also function to detect of the player is grounded or not for the 
public class PlayerControl : MonoBehaviour {
	//Variables:
	// speed- Used for the player's movement speed.
	// jumpForce - how forceful the player's jump is
	// jumpTimes - the total amount of times we can jump
	// isGrounded - checked to see if the player touched the ground or not (used as a trigger or switch)
	// jumpCount - used for storing the times we jumped
	// x - player's x input movement
	// y - player's y velocity
	// isJumping - check if the player is in the air
	// isRunning - check if the player is moving on the ground
	public float speed;
	public float jumpForce;
    public int jumpTimes;
    public bool isGrounded;
	public Rigidbody2D rb;
    public Animator anim;
    public AudioClip jumpSound;
    public AudioSource audioSource;
    public SpriteRenderer sr;

    private int jumpCount;
    private float x;
    private float y;
    private bool isJumping;
    private bool isRunning;
	
	// Update is called once per frame
	void Update () {
		//set x to input axis
		x= Input.GetAxis("Horizontal");
        y = rb.velocity.y;
		//transform the player
		transform.position += Vector3.right * x * Time.deltaTime*speed;

		if (Input.GetKeyDown (KeyCode.Space)&&jumpCount<jumpTimes) {
            isJumping = true ;
            jumpCount++;
	
            //play sound
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

		// These if statements are used for determining which direction the player should
		// be facing:
		//x > 0 = PLAYER IS MOVING RIGHT
		//x < 0 = PLAYER IS MOVING LEFT
        if (x > 0)
        {
            sr.flipX = false;
            x = 1;
        }
        if (x < 0)
        {
            sr.flipX = true;
            x = -1;
        }

    }

	//Called once after each frame
	//Function Use: Set the floats for the blending of our animation
    private void LateUpdate()
    {
        anim.SetFloat("InputX", x);
        anim.SetFloat("InputY", y);

    }

	//Function Use: If the collision id the floor, then we know that we are on the ground.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

	//If we exit the floor, we are in the air,
	// hence, not grounded.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }
		
    //Function Use: For some reason, the player is flipped when it respawns, to fix this
    //issue, we flip the x of the sprite renderer
    public void OnDisable()
    {
        sr.flipX = false;
    }
}
