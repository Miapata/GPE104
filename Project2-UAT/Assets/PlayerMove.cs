using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour {
    public GameManager manager;
    public Spawn spawn;
    Rigidbody2D rb;
    public Text text;
    public GameObject laser, center, explosion,directionSprite;
     float player_RotateSpeed, player_MoveSpeed,laserSpeed;
     int lives;
	// Use this for initialization
	void Start() {
        player_RotateSpeed = GameManager.instance.player_player_RotateSpeed;
        player_MoveSpeed = GameManager.instance.player_MoveSpeed;
        laserSpeed = GameManager.instance.laserSpeed;
        spawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawn>();
        lives = GameManager.instance.lives;
        text = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
        text.text = "Lives: " + lives.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 mousePositionVector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        mousePositionVector3 = Camera.main.ScreenToWorldPoint(mousePositionVector3);
        Vector3 targetdir = mousePositionVector3 - transform.position;

        

        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(0, 0,player_RotateSpeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -player_RotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, player_MoveSpeed * Time.deltaTime, 0);
        }

        //If down arrow is pressed
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Translate
            transform.Translate(0, -player_MoveSpeed * Time.deltaTime, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            GameObject newLaser = Instantiate(laser, transform.position, transform.rotation) as GameObject;
            Rigidbody2D rigid = newLaser.GetComponent<Rigidbody2D>();
            newLaser.transform.rotation = Quaternion.LookRotation(Vector3.forward, targetdir);
            rigid.velocity = newLaser.transform.up * laserSpeed;
            
        }

        //If space is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //Instantiate a laser
           var laserInstance= Instantiate(laser,center.transform.position,transform.rotation);
            
            //get rigidbody
            rb= laserInstance.GetComponent<Rigidbody2D>();

            //Set rigidbody's velocity to go in direction the player is facing
            rb.velocity = transform.up*laserSpeed;
            
        }
   
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
      

        lives--;
        if (lives == 0)
        {
            Application.Quit();
        }
        text.text = "Lives: " + lives.ToString();
        Instantiate(explosion,transform.position,Quaternion.identity);
            foreach (GameObject enemy in spawn.enemyList)
            {
            Destroy(enemy);

            if (enemy == null)
            {
                spawn.enemyList.Remove(enemy);
            }
                
            }
        }
    
}
