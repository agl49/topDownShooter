﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Weapon currentWeapon;

    private Transform firePoint;

    private bool ableToShoot = true;

    void Start()
    {
        firePoint = transform.Find("FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }
   
    public void shoot()
    {
        if(ableToShoot)
        {
            GameObject bullet = Instantiate(currentWeapon.bulletPrefab, 
                                                firePoint.position,
                                            firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * currentWeapon.bulletForce, ForceMode2D.Impulse);
        }
    }

    public void turnOffShooting()
    {
        ableToShoot = false;
    }
}