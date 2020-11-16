using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HitPoints;
    public float MaxHitPoints = 5;
    // Start is called before the first frame update
    void Start()
    {
        HitPoints = MaxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeHit(float damage)
    {
        HitPoints -= damage;
        if(HitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
