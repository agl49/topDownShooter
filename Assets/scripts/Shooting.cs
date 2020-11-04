using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    /*
    To be deleted maybe
    public Weapon currentWeapon;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            currentWeapon.shoot();
        }
    }
   
    public void shoot()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, 
                                        FirePoint.transform.position, 
                                        Quaternion.identity);
        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.addForce()
                                        
    }
             
        /*
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
   */


}