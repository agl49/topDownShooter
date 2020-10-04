using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
}
