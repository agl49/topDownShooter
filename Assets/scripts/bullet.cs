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
        var enemy = collision.collider.GetComponent<Enemy>();
        
        //Change hero_0 to some other name
        if(collision.gameObject.name != "player"){
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            if(enemy){
                enemy.TakeHit(damage);
            }
            Destroy(gameObject);
        }
        else{
          //  Destroy(gameObject);
        } 

   }
}
