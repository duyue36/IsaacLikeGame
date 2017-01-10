using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody2D player;
    private Vector3 larmeMovement;

    public GameObject larme;
    public Transform larmeSpawn;
    //private Rigidbody2D larmeRigidbody;

    public float fireRate;
    private float nextFire;

    private bool rightTurn;
    private Vector3 offsetLarmePosition;  //to control it's right larme or left larme

    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody2D>();

        rightTurn = true;
        offsetLarmePosition.Set(0.0f, 0.5f, 0.0f);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if(rightTurn == true)
                Instantiate(larme, larmeSpawn.position + offsetLarmePosition, larmeSpawn.rotation);
            else
                Instantiate(larme, larmeSpawn.position - offsetLarmePosition, larmeSpawn.rotation);

            rightTurn = !rightTurn;

        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        player.velocity = movement * speed;
        player.position = transform.position + movement;
    }

   
}
