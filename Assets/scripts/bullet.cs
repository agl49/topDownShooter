using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
   //For normal bullet
   public GameObject hitEffect; 

   
   void OnCollisionEnter2D(Collision2D collision)
   {
         var enemy = collision.collider.GetComponent<Enemy>();
        
        if(collision.gameObject.name != "hero_0"){
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            if(enemy){
                enemy.TakeHit(1);
            }
            Destroy(gameObject);
        }
        else{
          //  Destroy(gameObject);
        } 

   }
}
