using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
  public float moveSpeed = 2f;
  public float lineOfSite;
  public float shootingRange;
//    public float fireRate = 1f;
//    private float nextFireTime;
  public GameObject bullet;
  public GameObject bulletParent;
   private Transform player;

//    public Rigidbody2D rb;

//    Vector2 movement;

   void Start()
   {
       player = GameObject.FindGameObjectWithTag("Player").transform;

   }
    // Update is called once per frame
    void Update()
    {
          float distanceFromPlayer = Vector2.Distance(player.position,transform.position);
          if(distanceFromPlayer<lineOfSite && distanceFromPlayer > shootingRange){
              transform.position= Vector2.MoveTowards(this.transform.position,player.position, moveSpeed*Time.fixedDeltaTime);
          }
        else if(distanceFromPlayer <= shootingRange)
        {
            Instantiate(bullet, bulletParent.transform.position,Quaternion.identity);
            //  nextFireTime = Time.time + fireRate;
        }
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    // void FixedUpdate(){
    //     rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    // }
}
