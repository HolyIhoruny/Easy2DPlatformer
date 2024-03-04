using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Bullet;
    

    void Update()
    {
        

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    public void Shoot() 
    {
        Instantiate(Bullet, firePoint.position, firePoint.rotation);
    }
}