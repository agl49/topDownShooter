using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Weapon currentWeapon;

    private Transform firePoint;

    private float nextFire = -1f;

    private bool ableToShoot = true;

    void Start()
    {
        firePoint = transform.Find("FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        nextFire -= Time.deltaTime;
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }
   
    public void shoot()
    {
        ableToShoot = coolDown();
        if(ableToShoot)
        {
            GameObject bullet = Instantiate(currentWeapon.bulletPrefab, 
                                                firePoint.position,
                                            firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * currentWeapon.bulletForce, ForceMode2D.Impulse);

            nextFire = currentWeapon.fireRate;
            ableToShoot = coolDown();
        }
    }

    public bool coolDown()
    {
        bool canFire;
        if (nextFire > 0)
        {
            
            canFire = false;
        }
        else
            canFire = true;
        return canFire;
    }

    public void turnOffShooting()
    {
        ableToShoot = false;
    }
}
