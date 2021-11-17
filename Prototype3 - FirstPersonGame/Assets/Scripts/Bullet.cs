using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    public GameObject hitParticle;
    private float shootTime;

    void OnEnable()
    {
        shootTime = Time.time;
    }
    
    void OnTriggerEnter(Collider other)
    {
         //Create the hit particle effect
        GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        
        //destroy hit particle
        Destroy(obj, 0.5f);

        //what did we hit?
        if(other.CompareTag("Player"))
            other.GetComponent<BeanController>().TakeDamage(damage);
        else
            if(other.CompareTag("Enemy"))
                other.GetComponent<Enemy>().TakeDamage(damage);
        
        //Disable bullet
        gameObject.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }
}
