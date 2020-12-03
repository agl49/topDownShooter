using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotateSpeed = 200f;
    private Transform player;
    //private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
   //     target = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);

    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)player.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = speed * transform.up;
    }
}
