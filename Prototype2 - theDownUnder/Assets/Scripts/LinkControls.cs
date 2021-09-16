using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkControls : MonoBehaviour
{
    //Variable
    public float speed = 2.0f;
    public float turnSpeed = 10.0f;
    public float hInput;
    public float vInput;

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        // Link would like to move in different directions
        transform.Translate(Vector3.forward * speed * Time.deltaTime * hInput);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);
    }
}
