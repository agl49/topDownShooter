using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Camera cam;
    public float speed = 5f;
    public Weapon currentWeapon;
    public Transform firePoint;
    Vector2 movement;
    Vector2 mousePos;
    
    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
       getInput();
       if(Input.GetButtonDown("Fire1"))
       {
            shoot();
       }
   
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;

    }

    //Returning this to shoot might be a good idea
    void shoot()
    {
        GameObject bullet = Instantiate(currentWeapon.bulletPrefab, 
                                        firePoint.position,
                                        firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * currentWeapon.bulletForce, ForceMode2D.Impulse);
    }

    private void getInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
