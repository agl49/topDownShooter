using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public int damage = 1;

    public void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, 
                                        GameObject.Find("FirePoint").transform.position, 
                                        Quaternion.identity);
                                        
    }
}
