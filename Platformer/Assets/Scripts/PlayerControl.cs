using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
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
    // Use this for initialization
    void Start () {
	
	}
	
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

    private void LateUpdate()
    {

        
      
        anim.SetFloat("InputX", x);
        anim.SetFloat("InputY", y);



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }

    //We don't want out player to ever be destroyed!
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //For some reason, the player is flipped when the respawn, to fix this
    //issue, we flip the x of the sprite renderer
    public void OnDisable()
    {
        sr.flipX = false;
    }
}
