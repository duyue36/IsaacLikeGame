using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarmeController : MonoBehaviour {
    public float speed;
    private Vector3 larmeMovement;
    public float damage;

    public GameObject enemy;
    public Transform enemyPos;
    public float smoothing = 1f;

    Rigidbody2D larme;
    private bool enemyExist;
    private Collider2D enemyCollider;

    // Use this for initialization
    void Start () {
        larme = GetComponent<Rigidbody2D>();
        enemy = GameObject.Find("Enemy1");
        enemyPos = enemy.transform;
        enemyCollider = enemy.GetComponent<Collider2D>();

        enemyExist = false;
        


        OnTriggerEnter2D(enemyCollider);

    }
	
	// Update is called once per frame
	void Update () {
        LarmeMove();
	}

    void LarmeMove()
    {
        // Set the movement vector based on the axis input.
        larmeMovement.Set(speed, 0f, 0f);

        // Normalise the movement vector and make it proportional to the speed per second.
        larmeMovement = larmeMovement.normalized * speed * Time.deltaTime;

        
        //larme.MovePosition(transform.position + larmeMovement);

        if(enemyExist)
            larme.position = Vector3.Lerp(transform.position, enemyPos.position, smoothing * Time.deltaTime);
        else
            larme.MovePosition(transform.position + larmeMovement);  // Move the player to it's current position plus the movement.



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyExist = true;
        Debug.Log("enemyExist = " + enemyExist);
    }

}
