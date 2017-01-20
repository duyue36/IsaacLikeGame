using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour {
    public float speed;
    public float movingPeriod;// if enemy start to move, it will moving 2 seconds
    public Boundary boundary;

    Rigidbody2D enemyRigidbody;
    Vector2 movement;
    Vector2 zero;

    private Animator n_animator;
    private float itsThinkPeriod = 3f;   //every 3 seconds, Ai will make a decistion
    private float thinkTimeLeft;
    private float movingTimeLeft;  

    bool iWantToMove;            // if true Ai will move
    bool inMoving = false;


    // Use this for initialization
    void Start () {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        n_animator = GetComponent<Animator>();
        movingTimeLeft = movingPeriod;

        zero = new Vector2(0, 0);

        thinkTimeLeft = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void FixedUpdate()
    {
        decideMoveOrNot();
        if (iWantToMove)
        {

            decideDirection();
            
            if(movingTimeLeft > 0)
            {
                Move();
                movingTimeLeft -= Time.deltaTime;
            } 
        }

        if (movingTimeLeft <= 0)
        {
            enemyRigidbody.velocity = zero;
            inMoving = false;
            movingTimeLeft = movingPeriod;    //after x s, reset movingTimeLeft to x s.
        }

        enemyRigidbody.position = new Vector2
       (
           Mathf.Clamp(enemyRigidbody.position.x, boundary.xMin, boundary.xMax),
           Mathf.Clamp(enemyRigidbody.position.y, boundary.yMin, boundary.yMax)
        );
    }





    void Move()
    {
        enemyRigidbody.velocity = movement * speed * Time.deltaTime;
        //player.position = transform.position + movement;
       
    }

    void decideDirection()
    {
        enemyRigidbody.velocity = zero;
        float randomValue = Random.Range(0.0f, 1.0f);

        if(randomValue < 0.25)    // enemy will turn right
        {
            movement.Set(speed, 0);
            n_animator.SetTrigger("WalkRight");
        }
        else if(randomValue < 0.5) // enemy will turn left
        {
           
            movement.Set(-speed, 0);
            n_animator.SetTrigger("WalkLeft");
        }
        else if (randomValue < 0.75) // enemy will turn up
        {
            
            movement.Set(0, speed);
            n_animator.SetTrigger("WalkUp");
        }
        else // for randomValue between 0.75 and 1, enemy will turn down
        {
            
            movement.Set(0, -speed);
        }

        //Debug.Log(" movement = " + movement);


    }

    void decideMoveOrNot()   // for once a period of "itsThinkTime", AI will decide if he want to drink or not
    {
        iWantToMove = false;

        thinkTimeLeft -= Time.deltaTime;
        if (thinkTimeLeft <= 0)
        {
            if (Random.Range(0.0f, 1.0f) > 0.5f)
                iWantToMove = true;

            thinkTimeLeft = itsThinkPeriod;
        }


    }
}
