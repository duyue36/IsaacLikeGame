using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IssacController : MonoBehaviour {

    private Animator m_animator;

	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_animator.SetTrigger("Walkup");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_animator.SetTrigger("Walkdown");
            m_animator.SetTrigger("Blink");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_animator.SetTrigger("WalkRight");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_animator.SetTrigger("WalkLeft");
        }
    }
}
