using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
   //For normal bullet
   public GameObject hitEffect; 
   public float damage;
   
   void OnCollisionEnter2D(Collision2D collision)
   {
        if(collision.gameObject.CompareTag("enemy"))
        {
            var enemy = collision.collider.GetComponent<Enemy>();
        
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            if(enemy){
                enemy.TakeHit(damage);
            }
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            var player = collision.collider.GetComponent<player>();
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            player.getHit(damage);
            Destroy(gameObject);
        }
        else
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            Destroy(gameObject);
        }
   }
}
