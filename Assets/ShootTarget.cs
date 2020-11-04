using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTarget : MonoBehaviour
{
    GameObject target;
    //  public Transform firePoint;
    public float speed;
    Rigidbody2D bulletRB;
    // public float bulletForce = 20f;
    // public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent< Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDirection = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(this.gameObject,2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //  void Shoot()
    // {
    //     GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //     Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    //     rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    // }
}
