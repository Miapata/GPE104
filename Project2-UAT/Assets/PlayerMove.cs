using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : Photon.MonoBehaviour {
   	
	//Variables
    Rigidbody2D rb;
    public Text text;
    private Vector3 mousePosition;
    public GameObject  center,directionSprite;
	public bool canFire, isFlipped;
    public float fireRate;
    public PhotonView player_PhotonView;

	// Use this for initialization
	void Start() {

		//Find text component
        text = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();

		//set text to lives
		text.text = "Lives: " + GameManager.instance.lives.ToString();
    }


	//When the script is enabled
	void OnEnable(){
			//Set player to this
		try {
			GameManager.instance.player = gameObject;
		} catch (System.Exception ex) {
			
		}
			

	}

	// Update is called once per frame
	void Update () {
        if (player_PhotonView.isMine)
        {
            //If LEFT or A is pressed
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {

                //Roatate
                transform.Rotate(0, 0, GameManager.instance.player_RotateSpeed * Time.deltaTime);
            }

            //If RIGHT or D is pressed
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {

                //Rotate
                transform.Rotate(0, 0, -GameManager.instance.player_RotateSpeed * Time.deltaTime);
            }

            //If UP or W is pressed
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {

                //transform
                transform.Translate(0, GameManager.instance.player_MoveSpeed * Time.deltaTime, 0);

            }

            //If DOWN or S is pressed
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {

                //Translate
                transform.Translate(0, GameManager.instance.player_MoveSpeed * Time.deltaTime, 0);

            }



            //Check if MouseButton is Down
            if (Input.GetMouseButton(0))
            {
                //If can fire is true
                if (canFire)
                {
                    //Start Coroutine
                    StartCoroutine(Laser());
                }
            }


            //If space is pressed down
            if (Input.GetKeyDown(KeyCode.Space))
            {

                //Instantiate a laser
                var laserInstance = PhotonNetwork.Instantiate(GameManager.instance.laser.name, transform.position, transform.rotation,0);

                //get rigidbody
                rb = laserInstance.GetComponent<Rigidbody2D>();

                //Set rigidbody's velocity to go in direction the player is facing
                rb.velocity = transform.up * GameManager.instance.laserSpeed;

            }
        }
    }

	//When script is disabled
	void OnDisable(){
        if (player_PhotonView.isMine)
        {
            //Set can fire to true
            canFire = true;

            //Set text to lives
            text.text = "Lives: " + GameManager.instance.lives.ToString();
        }
	}

	//Used for rate of fire
    IEnumerator Laser()
    {

		//Set canFire to true
        canFire = false;

		//Wait 
        yield return new WaitForSeconds(fireRate);

		//get mouseposition in Vector3
        Vector3 mousePositionVector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);

		//convert it to World space
        mousePositionVector3 = Camera.main.ScreenToWorldPoint(mousePositionVector3);

		//get direction for laser
        Vector3 targetdir = mousePositionVector3 - transform.position;

		//Instantiate the laser
		GameObject newLaser = PhotonNetwork.Instantiate(GameManager.instance.laser.name, transform.position, transform.rotation,0) as GameObject;

		//Get the rigid body
        Rigidbody2D rigid = newLaser.GetComponent<Rigidbody2D>();

		//look towards the targer direction
        newLaser.transform.rotation = Quaternion.LookRotation(Vector3.forward, targetdir);

		//Set velocty to forward
        rigid.velocity = newLaser.transform.up * GameManager.instance.laserSpeed;

		//You are now able to fire again
        canFire = true;
    }

    //On collision with enemies
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (player_PhotonView.isMine)
        {
            //Subtract lives
            GameManager.instance.lives--;

            //Game Over
            if (GameManager.instance.lives == 0)
            {
                //Quit
                Application.Quit();
            }

            //Set text to lives
            text.text = "Lives: " + GameManager.instance.lives.ToString();

            //Instantiate explosion
            PhotonNetwork.Instantiate(GameManager.instance.explosion.name, transform.position, Quaternion.identity,0);

            //Delete every enemy
            foreach (GameObject enemy in GameManager.instance.enemyList)
            {
                PhotonNetwork.Destroy(enemy);

                if (enemy == null)
                {

                    GameManager.instance.enemyList.Remove(enemy);
                }

            }
        }
    }
    
}
