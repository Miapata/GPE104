using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {
    //Rigidbody
    public Rigidbody2D rb;

    //Player
    public GameObject player;

    //Floats
    float enemy_Speed, enemy_player_RotateSpeed;
	// Use this for initialization
	void Start () {

        enemy_Speed = GameManager.instance.enemy_Speed;
        enemy_player_RotateSpeed=GameManager.instance.enemy_player_RotateSpeed;

        //Gind the rigidbody
        rb = GetComponent < Rigidbody2D > ();

        //Find the player
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //Get a vector direction
        Vector2 point2Target = (Vector2)transform.position - (Vector2)player.transform.position;

        //Normalize the target
        point2Target.Normalize();

        //Find the cross product
        float value = Vector3.Cross(point2Target, transform.up).z;

        //If value is 0
        if (value > 0)
        {
            //set angular velocity
            rb.angularVelocity = enemy_player_RotateSpeed;
        }

        //Else if value is less than 0
        else if (value < 0)

            //Set angular
            rb.angularVelocity = -enemy_player_RotateSpeed;
        //Else

        else
            //Angular velocity is 0

            rb.angularVelocity = 0;

        //Set velocity to rotating speed and value
        rb.angularVelocity = enemy_player_RotateSpeed * value;

        //Velocity is transform up times the forceSpeed
        rb.velocity = transform.up * enemy_Speed;



    }
}
