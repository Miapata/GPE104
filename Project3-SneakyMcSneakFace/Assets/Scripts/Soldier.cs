﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Derives from Controller
public class Soldier : Controller
{
    //Spotted image
    public GameObject spotted;

    //Canvas
    public GameObject canvas;

    public GameObject gameOverCanvas;

    //Text for the times Spotted
    public Text text;

	//AISense Script
	AISense sense;


	// Use this for initialization
	void Start ()
	{

        //Set the curren state to patrolling
		currentState = AIStates.Patrol;

        //sense is the component of our enemy
		sense = GetComponent<AISense>();
	}

	// Update is called once per frame
	void Update()
	{
        
        //Do the state Machine
        StateMachine(spotted, text, sense);

        //Set the canvas position to us
        canvas.transform.position = transform.position;

	}

	//This is the state for the collision 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameStateManager.instance.states = GameStateManager.States.GameOver;
        }
    }
}
