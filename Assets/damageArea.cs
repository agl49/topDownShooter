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
    
    [SerializeField]
    private float attackDelay = 2f;

    void Start()
    {
        waitForNextDamage = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("We are in trigger");

        if(other.CompareTag("Player"))
        {
            if(waitForNextDamage == false)
            {
                myTrigger.Invoke();
                StartCoroutine(waitBeforeAttackCoroutine());
            }
            //Debug.Log("we found player");
            //var player = collision.GetComponent<Collider>().GetComponent<player>();
        
            //player?.getHit(damage, gameObject); 
        }
    }

    IEnumerator waitBeforeAttackCoroutine()
    {
        waitForNextDamage = true;
        yield return new WaitForSeconds(attackDelay);
        waitForNextDamage = false;        
    }
}
