using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public enum BULLETDIR
{
    LEFTSHOOT,
    RIGHTSHOOT,
    UPSHOOT,
    DOWNSHOOT
}
namespace Globalspace
{
   
    public class PlayerController : MonoBehaviour
    {    
        public static BULLETDIR bulletDir;
        public static bool inBiggerMode;
        public static bool inTrackMode;
        public static Transform enemyPos;
        public static float playerBulletSpeed;
        public static float bulletDamage;

        private Rigidbody2D player;
        private Vector3 larmeMovement;
        public Boundary boundary;

        public GameObject larme;
        public Transform larmeSpawn;
        public Transform enemyPosition;

        //private Rigidbody2D larmeRigidbody;

        public Toggle normal;
        public Toggle greater;
        public Toggle tracer;

        public Slider speedSlider;      // 0 ~ 20
        public Slider fireRateSlider;   // 0 ~ 1
        public Slider bulletSpeedSlider;// 0 ~ 20
        public Slider damageSlider;     // 0 ~ 20

        private float speed;
        private float fireRate;
        private float nextFire;

        private bool rightTurn;
        private Vector3 offsetLarmePositionY;  //to control it's right larme or left larme
        private Vector3 offsetLarmePositionX;

        


        // Use this for initialization

        void Start()
        {
            speed = speedSlider.value;
            fireRate = fireRateSlider.value;
            playerBulletSpeed = bulletSpeedSlider.value;
            bulletDamage = damageSlider.value;

            player = GetComponent<Rigidbody2D>();
            enemyPos = enemyPosition;

            rightTurn = true;
            offsetLarmePositionY.Set(0.0f, 0.3f, 0.0f);
            offsetLarmePositionX.Set(0.3f, 0.0f, 0.0f);

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                bulletDir = BULLETDIR.UPSHOOT;
                if (rightTurn == true)
                    Instantiate(larme, larmeSpawn.position + offsetLarmePositionX, larmeSpawn.rotation);
                else
                    Instantiate(larme, larmeSpawn.position - offsetLarmePositionX, larmeSpawn.rotation);

                rightTurn = !rightTurn;
            }
            if (Input.GetKey(KeyCode.DownArrow) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                bulletDir = BULLETDIR.DOWNSHOOT;
                if (rightTurn == true)
                    Instantiate(larme, larmeSpawn.position + offsetLarmePositionX, larmeSpawn.rotation);
                else
                    Instantiate(larme, larmeSpawn.position - offsetLarmePositionX, larmeSpawn.rotation);

                rightTurn = !rightTurn;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                bulletDir = BULLETDIR.LEFTSHOOT;
                if (rightTurn == true)
                    Instantiate(larme, larmeSpawn.position + offsetLarmePositionY, larmeSpawn.rotation);
                else
                    Instantiate(larme, larmeSpawn.position - offsetLarmePositionY, larmeSpawn.rotation);

                rightTurn = !rightTurn;
            }

            if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                bulletDir = BULLETDIR.RIGHTSHOOT;
                if (rightTurn == true)
                    Instantiate(larme, larmeSpawn.position + offsetLarmePositionY, larmeSpawn.rotation);
                else
                    Instantiate(larme, larmeSpawn.position - offsetLarmePositionY, larmeSpawn.rotation);

                rightTurn = !rightTurn;
            }

            speed = speedSlider.value;
            fireRate = fireRateSlider.value;
            playerBulletSpeed = bulletSpeedSlider.value;
            bulletDamage = damageSlider.value;

            /*
            if (Input.GetKey(KeyCode.UpArrow) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                //Debug.Log("Time.time = " + Time.time);

                if (rightTurn == true)
                    Instantiate(larme, larmeSpawn.position + offsetLarmePositionY, larmeSpawn.rotation);
                else
                    Instantiate(larme, larmeSpawn.position - offsetLarmePositionY, larmeSpawn.rotation);

                rightTurn = !rightTurn;

            }
            */

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

        public void Toggle_Changed_Normal(bool newValue)
        {
            if (newValue)
            {
                inBiggerMode = false;
                inTrackMode = false;
            }
        }

        public void Toggle_Changed_Greater(bool newValue)
        {
            if (newValue)
            {
                inBiggerMode = true;
                inTrackMode = false;
            }

        }

        public void Toggle_Changed_Tracer(bool newValue)
        {
            if (newValue)
            {
                inBiggerMode = false;
                inTrackMode = true;
            }

        }


    }
}

