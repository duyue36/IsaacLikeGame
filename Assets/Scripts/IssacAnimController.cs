using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IssacAnimController : MonoBehaviour {

    private Animator m_animator;

	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
        {
            m_animator.SetTrigger("Walkup");
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_animator.SetTrigger("Walkdown");
            //m_animator.SetTrigger("Blink");
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_animator.SetTrigger("WalkLeft");
           
        }
       

        if (Input.GetKey(KeyCode.D))
        {
            m_animator.SetTrigger("WalkRight");
        }

        
    }
}
