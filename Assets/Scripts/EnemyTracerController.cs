using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracerController : MonoBehaviour {
    public Transform playerTransform;
    public float speed;

    public Boundary boundary;

    Rigidbody2D enemyRigidbody;

    private float startTime;     
    private float journeyLength;
    private Transform originTransform;
   

    // Use this for initialization
    void Start () {
        enemyRigidbody = GetComponent<Rigidbody2D>();

        originTransform = transform;

        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, playerTransform.position);
    }
	
	// Update is called once per frame
    void Update()
    {
        
    }
	void FixedUpdate () {
        TrackMode();
    }


    void TrackMode()                     //this function will move from a start position to the end position gradually
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        enemyRigidbody.position = Vector3.Lerp(originTransform.position, playerTransform.position, fracJourney / 10);

        enemyRigidbody.position = new Vector2
      (
          Mathf.Clamp(enemyRigidbody.position.x, boundary.xMin, boundary.xMax),
          Mathf.Clamp(enemyRigidbody.position.y, boundary.yMin, boundary.yMax)
       );
    }
}
