using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Health,
    Ammo
}

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int value;

    [Header("Bobbing Animation")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;

    private Vector3 startPos;
    private bool bobUp;

    void Start()
    {
        //Set the start position
        startPos = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            BeanController player = other.GetComponent<BeanController>();

            switch(type)
            {
                case PickupType.Health:
                player.GiveHealth(value);
                break;

                case PickupType.Ammo:
                player.GiveAmmo(value);
                break;
            }

            Destroy(gameObject);
        }
    }

    void Update()
    {
        //rotating
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        Vector3 offset = (bobUp == true ? new Vector3(0,bobHeight/2, 0) : new Vector3(0, -bobHeight/2, 0));
        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        if(transform.position == startPos + offset)
            bobUp = !bobUp;
    }
}
