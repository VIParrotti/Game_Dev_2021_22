using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehavior
{
    public GameObject tank;
    private Vector3 offset = new Vector3(0, 50, -80);
    void Update()
    {
        transform.position = tank.transform.postion + offset;
    }
}