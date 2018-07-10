using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is the controller for the player and the AI
public abstract class Controller : MonoBehaviour {

    //Enum for the states
    public enum AIStates
    {
        Patrol,
        ChaseAndFire
    }

    //Decalre a state
    public AIStates currentState;

    //Enemy speed
    public float speed = 10.0f;

    //Enemy Rotation speed
    public float rotationSpeed = 180.0f;

    //Used to store times spotted
    int timesSpotted;

    //Used for spotting the character
    public bool isSpotted;

    //Audio source 
    public AudioSource footstep;

    //Virtual method for moving our player
    public virtual void MovePlayer(float speed, float rotationSpeed)
    {
        //Move Up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }

        //Move Down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Time.deltaTime * speed, 0, 0);
        }

        //Rotate Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
        }

        //Rotate Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -Time.deltaTime * rotationSpeed);
        }

        //If anykey is pressed
        if (Input.anyKey)
        {
            //Check if the audiosource is playing
            if (!footstep.isPlaying)
            {

                //Play the footsped sound
                footstep.Play();
            }
        }
        else
        {

            //Stop the footstep sound
            footstep.Stop();
        }
        
    }


    //Enemy State Machine Virtual method
        public virtual void StateMachine(GameObject spotted, Text text, AISense sense) {

       
        // AI States are based on enum value
        switch (currentState)
        {
            //If the currentstate is Patroling
            case AIStates.Patrol:
                // Do patrol work
                spotted.SetActive(false);
                Patrol(text,sense);
                break;

            //If the current state is chasing
            case AIStates.ChaseAndFire:
                // Do patrol work
                spotted.SetActive(true);
                ChaseAndFire(sense);
                break;

        }
    }


    //Patrol method for rotating
    void Patrol(Text text, AISense sense)
    {
        isSpotted = false;
        // Do Patrol
        transform.Rotate(0, 0, -Time.deltaTime * rotationSpeed);

        // Check for Transitions
        if (sense.CanSee(GameManager.instance.player)||sense.CanHear(GameManager.instance.player,GameManager.instance.noiseMaker.volume))
        {
            //Since spotted, increase the counter
            text.text = "Times Spotted: " + ++timesSpotted;

            //currentstate is now Chasing
            currentState = AIStates.ChaseAndFire;
        }
    }

    //Abstract classes are never used by the parent, only the child

    //Chase the player
    void ChaseAndFire(AISense sense)
    {
        isSpotted = true;

        //This is used to get a direction from the player and our current position
        Vector2 dir = GameManager.instance.player.transform.position - transform.position;

        //Get the angle of the direction
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //Angel axis
        Quaternion qto = Quaternion.AngleAxis(angle, Vector3.forward);

        //Euler
        Quaternion qto2 = Quaternion.Euler(qto.eulerAngles.x,
                                            qto.eulerAngles.y,
                                            qto.eulerAngles.z);

        //Set the rotation
        transform.rotation = qto2;

        //Move up, What ever direction the enemy is facing he will move towards it
        transform.position += transform.right * 2 * Time.deltaTime;

        //If we cannot see the player
        if (!sense.CanSee(GameManager.instance.player))
        {

            //Set the current state to patrol
            currentState = AIStates.Patrol;
        }
    }


}
