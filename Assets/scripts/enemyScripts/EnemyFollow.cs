using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is for enemy who shoots stuff
public class EnemyFollow : MonoBehaviour
{
  [SerializeField] private float lineOfSite;
  [SerializeField] private float shootingRange;
  [SerializeField] private float fireRate = 1f;
  [SerializeField] private float bulletForce = 20f;
  [SerializeField] private bool homing = false;
  [SerializeField] private bool meele = false;
  [SerializeField] private float meeleRange;
  [SerializeField] private float meeleDamage = 0;
  [SerializeField] private float punchRate = 1f;
  [SerializeField] private GameObject thePlayer;
  private player playerScript;
  private float nextFireTime;
  private float nextPunchTime;
  public GameObject prefabBullet;
  [SerializeField] private Transform bulletParent;
  private Transform playerT;
  private float distanceFromPlayer;
  [SerializeField] private float velocity = 5f;
  private Vector2 playerDirection;
  
  [SerializeField] private Rigidbody2D body;

//    Vector2 movement;

   void Start()
   {
       playerT = GameObject.FindGameObjectWithTag("Player").transform;
       playerScript = thePlayer.GetComponent<player>();
   }
    // Update is called once per frame
    void Update()
    {    
          distanceFromPlayer = Vector2.Distance(playerT.position,transform.position);

          if(distanceFromPlayer<lineOfSite && distanceFromPlayer > shootingRange)
          {
              playerDirection = playerT.position - transform.position;
          }
          
          if(meele && distanceFromPlayer <= meeleRange && nextPunchTime < Time.time)
          {
              playerScript.getHit(meeleDamage);
              nextPunchTime = Time.time + punchRate;
          }
          
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        Gizmos.DrawWireSphere(transform.position, meeleRange);
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, playerDirection);
        //Gizmos.color = Color.blue;
        //Gizmos.DrawLine(body.velocity, transform.position);
    }

    void FixedUpdate()
    {
        if(distanceFromPlayer <= lineOfSite)
        {
           turnTowardsPlayer(); 
        }

        //rb movement
        if(distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            body.velocity = playerDirection.normalized * velocity;
        }
        else 
        {
            body.velocity = playerDirection.normalized * 0;
        }
        
        if(distanceFromPlayer <= shootingRange && nextFireTime < Time.time && distanceFromPlayer > meeleRange)
        {
            if(homing)
            {
                 Instantiate(prefabBullet, bulletParent.transform.position, Quaternion.identity);
                 nextFireTime = Time.time + fireRate;
            }
            else
            {
                 GameObject bullet = Instantiate(prefabBullet, bulletParent.transform.position, bulletParent.rotation);
                 Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                 rb.AddForce(bulletParent.up * bulletForce, ForceMode2D.Impulse);  
                 nextFireTime = Time.time + fireRate;
            }
        }
    
    }

    private void turnTowardsPlayer()
    {
        Vector2 playerPos = playerT.position;    
        Vector2 lookDir = playerPos - body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        body.rotation = angle;
    }
}
