using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class damageArea : MonoBehaviour
{
    //[SerializeField]
    //private float damage = 9f;

    [SerializeField]
    private UnityEvent myTrigger;

    private bool waitForNextDamage;

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("We are in trigger");

        if(other.CompareTag("Player"))
        {
            //Debug.Log("we found player");
            myTrigger.Invoke();
            //var player = collision.GetComponent<Collider>().GetComponent<player>();
        
            //player?.getHit(damage, gameObject); 
        }
    }
}
