using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;
    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;
    public float shootRate;
    public float bulletSpeed;
    private float lastShootTime;
    private bool isPlayer;

    void Awake()
    {
        //are we attached to the player?
        if(GetComponent<BeanController>())
        {
            isPlayer = true;
        }
    }
    
    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
                return true;
        }
        return false;
    }

    public void Shoot()
    {
        lastShootTime = Time.time;
        curAmmo--;
        GameObject bullet = Instatiate(bulletPrefab, muzzle.position, muzzle.rotation);

        //set velocity
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
