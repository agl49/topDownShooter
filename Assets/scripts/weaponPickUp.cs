using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickUp : MonoBehaviour
{
    public Weapon weapon;

    public void OnTriggerEnter2D(Collider2D target)
    {
        //Debug.Log(target.tag == "Player");
        
        if(target.tag == "Player")
        {
            Weapon current = target.GetComponent<Shooting>().currentWeapon;
            target.GetComponent<Shooting>().currentWeapon = weapon;
            current = target.GetComponent<Shooting>().currentWeapon;
            Destroy(gameObject);
        }
        
    }
}
