using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkControls : MonoBehaviour
{
    //Variable
    public float speed = 5.0f;
    public float turnSpeed = 10.0f;
    public float hInput;
    public float vInput;

    public float xRange = 8.91f;
    public float yRange = 4.46f;

    public GameObject bullet;
    private Vector3 offset = new Vector3(0,1,0);

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        // Link would like to move in different directions
        transform.Translate(Vector3.right * speed * Time.deltaTime * hInput);
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);

        //left and right boundaries
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        //top and bottom boundaries
        if(transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + offset, bullet.transform.rotation);
        }
    
    }
}
