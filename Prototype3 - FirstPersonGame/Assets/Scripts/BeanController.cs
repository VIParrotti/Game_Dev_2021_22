using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5.0f;
    public float jumpForce;

    [Header("Camera")]
    public float lookSensitivity;  //mouse look sensitivity
    public float maxLookX;  //lowest down position we can look
    public float minLookX;  //highest up we can look
    private float rotX;  //current X rotation of the camera

    [Header("Game Objects & Components")]
    private Camera cam;
    private Rigidbody rb;
    private Weapon weapon;
    

    [Header("Stats")]
    public int curHP;
    public int maxHP;
    public int damage;

    void Awake()
    {
        //Get components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        weapon = GetComponent<Weapon>();
        //disable cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0)
            Die();
    }

    void Die()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        if(Input.GetButtonDown("Jump"))
            Jump();
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
    }

    void Move()
    {
        float x  = Input.GetAxis("Horizontal") * moveSpeed;
        float z  = Input.GetAxis("Vertical") * moveSpeed;

        //face direction of camera
        Vector3 dir = transform.right * x + transform.forward * z;
        //jump direction
        dir.y = rb.velocity.y;
        //move in direction of camera
        rb.velocity = dir;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
        //clamps camera's up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        //apply rotation to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y;
    }
    
}
