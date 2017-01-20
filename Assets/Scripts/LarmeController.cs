using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Globalspace;


public class LarmeController : MonoBehaviour {
    private float bulletSpeed;
    private Vector3 larmeMovement;
    private float damage;

    public GameObject enemy;
    //public Transform enemyPos;

    //public bool inBiggerMode = false;
    //public bool inTrackMode = false;
    //public float smoothing = 1f;

    Rigidbody2D larme;
    private bool enemyExist;
    private Collider2D enemyCollider;

    private float startTime;     // for the track bullet
    private float journeyLength;

    // Use this for initialization
    void Awake()
    {
        bulletSpeed = PlayerController.playerBulletSpeed;
        damage = PlayerController.bulletDamage;
    }

    void Start () {
       
        larme = GetComponent<Rigidbody2D>();
        enemy = GameObject.Find("Enemy1");
        //enemyPos = enemy.transform;
        //enemyCollider = enemy.GetComponent<Collider2D>();

        enemyExist = false;

        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, PlayerController.enemyPos.position);

        BULLETDIR bulletDirction = PlayerController.bulletDir;


        switch (bulletDirction)
        {
            case BULLETDIR.UPSHOOT:
                MoveUp();
                break;
            case BULLETDIR.DOWNSHOOT:
                MoveDown();
                break;
            case BULLETDIR.LEFTSHOOT:
                MoveLeft();
                break;
            case BULLETDIR.RIGHTSHOOT:
                MoveRight();
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //LarmeMove();
        //OnTriggerEnter2D(enemyCollider);
       
    }

    public void MyListener(bool value)
    {

    }

    void FixedUpdate()
    {
        if (PlayerController.inBiggerMode)
            BiggerMode();
        if (PlayerController.inTrackMode)
            TrackMode();
    }

    void LarmeMove()
    {
        // Set the movement vector based on the axis input.
        larmeMovement.Set(bulletSpeed, 0f, 0f);

        // Normalise the movement vector and make it proportional to the speed per second.
        larmeMovement = larmeMovement.normalized * bulletSpeed * Time.deltaTime;

        
        larme.MovePosition(transform.position + larmeMovement);

        /* this a following missile
        if(enemyExist)
            larme.position = Vector3.Lerp(transform.position, enemyPos.position, speed * Time.deltaTime);
        else
            larme.MovePosition(transform.position + larmeMovement);  // Move the player to it's current position plus the movement.
        */


    }

    void MoveRight()
    {
        Vector2 goRight = new Vector2(1, 0);
        larme.velocity = goRight * bulletSpeed;

       
    }

    void MoveLeft()
    {
        Vector2 goLeft = new Vector2(-1, 0);
        larme.velocity = goLeft * bulletSpeed;
    }

    void MoveUp()
    {
        Vector2 goUp = new Vector2(0, 1);
        larme.velocity = goUp * bulletSpeed;
    }

    void MoveDown()
    {
        Vector2 goDown = new Vector2(0, -1);
        larme.velocity = goDown * bulletSpeed;
    }

    void BiggerMode()
    {
        larme.transform.localScale += new Vector3(0.3f, 0.3f, 0);
    }

    void TrackMode()
    {
        float distCovered = (Time.time - startTime) * bulletSpeed;
        float fracJourney = distCovered / journeyLength;
        larme.position = Vector3.Lerp(larme.transform.position, PlayerController.enemyPos.position, fracJourney / 4);
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyExist = true;
        //Debug.Log("enemyExist = " + enemyExist);
    }
    */
    
}
