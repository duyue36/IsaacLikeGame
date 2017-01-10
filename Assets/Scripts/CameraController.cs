using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject followObject;

    Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - followObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 followCampos = followObject.transform.position + offset;
        transform.position = followCampos;
    }
}
