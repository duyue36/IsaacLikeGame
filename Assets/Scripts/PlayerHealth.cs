using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Globalspace;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 3;
    public int currentHealth;
    public Image health3;
    public Image health2;
    public Image health1;

    //GameObject player;

    Animator anim;
    //Animator bodyAnimator;
    PlayerController playerController;
    bool isDead;                                                
    bool damaged;

    void Awake()
    {
        anim = GetComponent<Animator>();
        //bodyAnimator = GameObject.Find("Isaac/Isaac_body").GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();

        currentHealth = maxHealth;
    }
        // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void TakeDamage()
    {
        currentHealth--;
        if(currentHealth == 2)
        {
            health3.enabled = false;
        }
        if(currentHealth == 1)
        {
            health2.enabled = false;
        }

        if (currentHealth <= 0 && !isDead)
        {
            health1.enabled = false;
            // ... it should die.
            Death();
        }
    }

    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Tell the animator that the player is dead.
        anim.SetTrigger("Die");
        //bodyAnimator.enabled = false;

        // Turn off the playerController scripts.
        playerController.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        // If the entering collider is the player...
        if (other.gameObject.tag == "Enemy" )
        {
            Debug.Log("current health = " + currentHealth);
            TakeDamage();
        }
    }
}
