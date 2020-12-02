using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite WeaponSprite;
    public GameObject bulletPrefab;
    public float fireRate = 1;
    public float bulletForce = 20f;
    public string gunName;
}
