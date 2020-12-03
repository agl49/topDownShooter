﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Seems to just make an enemy move around 
public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;
    
    public Transform moveSpot;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    void Start()
    {
        
        moveSpot.position = new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
        
    }

   
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f){
            if(waitTime <= 0){
               
                moveSpot.position = new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
                waitTime = startWaitTime;
            }else {
                waitTime -= Time.deltaTime;
            }
        }
        
    }
}
