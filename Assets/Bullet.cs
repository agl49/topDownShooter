using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Enemy>();
        
        if(collision.gameObject.name != "hero_0"){
            if(enemy){
                enemy.TakeHit(1);
            }
            Destroy(gameObject);
        }        
    }
}
