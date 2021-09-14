using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehavior
{
    private float speed = 25.0f;
    private float turnSpeed = 50.0f;
    private float hInput;
    private float vInput;

    //Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput)
        transform.Rotate(Vector3.up * turnSpeed * hInput * Time.deltaTime)

    }
}