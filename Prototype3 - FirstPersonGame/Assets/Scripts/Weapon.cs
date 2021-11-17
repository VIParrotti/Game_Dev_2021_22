using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Transform muzzle;

    public float bulletSpeed;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;


    public float shootRate;
    private float lastShootTime;
    private bool isPlayer;

    void Awake()
    {
        // are we attached to the player?
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

      GameObject bullet = bulletPool.GetObject();
      bullet.transform.position = muzzle.position;
      bullet.transform.rotation = muzzle.rotation;

      // set the velocity
      bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed; 
    }
}
