using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public string pickupName;
    public int amount;

    public GameManager gameManager;

    // Start is called before the first frame update
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            print("You picked up a small key!");
            gameManager.hasKey = true;
            Destroy(gameObject);
        }
    }
}
