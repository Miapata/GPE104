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
    private int jumpCount;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//set x to input axis
		float x= Input.GetAxis("Horizontal");

		//transform the player
		transform.position += Vector3.right * x * Time.deltaTime*speed;


		if (Input.GetKeyDown (KeyCode.Space)&&jumpCount<jumpTimes) {
            jumpCount++;

            
            //play sound
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            if (x < 0)
            {
                anim.Play("Jumping Left");
            }
            if(x>0)
            {
                anim.Play("Jumping Right");
            }
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (x != 0)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
   
        }
        if (x > 0)
        {
            anim.SetBool("walkingRight", true);
            anim.SetBool("walkingLeft", false);
        }
        if (x < 0)
        {
            anim.SetBool("walkingLeft", true);
            anim.SetBool("walkingRight", false);
        }

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
}
