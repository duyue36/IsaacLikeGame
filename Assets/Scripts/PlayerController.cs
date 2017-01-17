using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {    //hi, can you see the change that I make it here?
    public float speed;
    private Rigidbody2D player;
    private Vector3 larmeMovement;
    public Boundary boundary;

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
        offsetLarmePosition.Set(0.0f, 0.3f, 0.0f);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //Debug.Log("Time.time = " + Time.time);

            if (rightTurn == true)
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
        //player.position = transform.position + movement;
        player.position = new Vector3
        (
            Mathf.Clamp(player.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(player.position.y, boundary.yMin, boundary.yMax),
            0.0f
         );
    }

   
}
