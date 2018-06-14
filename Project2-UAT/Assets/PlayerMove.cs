using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour {
    public GameManager manager;
   
    Rigidbody2D rb;
    public Text text;
    private Vector3 mousePosition;
    public GameObject laser, center, explosion,directionSprite;
     float player_RotateSpeed, player_MoveSpeed,laserSpeed;
     int lives;
	// Use this for initialization
	void Start() {
       
        text = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
		text.text = "Lives: " + GameManager.instance.lives.ToString();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (GameManager.instance.newMode)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, 3);

            //If space is pressed down
            if (Input.GetKeyDown(KeyCode.Space))
            {

                //Instantiate a laser
                var laserInstance = Instantiate(laser, center.transform.position, transform.rotation);

                //get rigidbody
                rb = laserInstance.GetComponent<Rigidbody2D>();

                //Set rigidbody's velocity to go in direction the player is facing
                rb.velocity = transform.up * GameManager.instance.laserSpeed;

            }

        }

        else
        {
            if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, 0, GameManager.instance.player_RotateSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 0, -GameManager.instance.player_RotateSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, GameManager.instance.player_MoveSpeed * Time.deltaTime, 0);
            }

            //If down arrow is pressed
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                //Translate
                transform.Translate(0, -GameManager.instance.player_MoveSpeed * Time.deltaTime, 0);
            }

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePositionVector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
                mousePositionVector3 = Camera.main.ScreenToWorldPoint(mousePositionVector3);
                Vector3 targetdir = mousePositionVector3 - transform.position;
                GameObject newLaser = Instantiate(laser, transform.position, transform.rotation) as GameObject;
                Rigidbody2D rigid = newLaser.GetComponent<Rigidbody2D>();
                newLaser.transform.rotation = Quaternion.LookRotation(Vector3.forward, targetdir);
                rigid.velocity = newLaser.transform.up * GameManager.instance.laserSpeed;

            }


            //If space is pressed down
            if (Input.GetKeyDown(KeyCode.Space))
            {

                //Instantiate a laser
                var laserInstance = Instantiate(laser, center.transform.position, transform.rotation);

                //get rigidbody
                rb = laserInstance.GetComponent<Rigidbody2D>();

                //Set rigidbody's velocity to go in direction the player is facing
                rb.velocity = transform.up * GameManager.instance.laserSpeed;

            }
        }
   
    }

     void OnCollisionEnter2D(Collision2D collision)
    {


        GameManager.instance.lives--;
        if (GameManager.instance.lives == 0)
        {
            Application.Quit();
        }
		text.text = "Lives: " + GameManager.instance.lives.ToString();
        Instantiate(explosion,transform.position,Quaternion.identity);
            foreach (GameObject enemy in GameManager.instance.enemyList)
            {
            Destroy(enemy);

            if (enemy == null)
            {
				//Jesus
				GameManager.instance.enemyList.Remove(enemy);
            }
                
            }
        }
    
}
