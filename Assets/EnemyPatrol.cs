using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;
    // public Transform [] moveSpots;
    public Transform moveSpot;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    // private int randomSpot;
    // Start is called before the first frame update
    void Start()
    {
        // randomSpot = Random.Range(0,moveSpots.Length);
        moveSpot.position = new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f){
            if(waitTime <= 0){
                // randomSpot = Random.Range(0,moveSpots.Length);
                moveSpot.position = new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
                waitTime = startWaitTime;
            }else {
                waitTime -= Time.deltaTime;
            }
        }
        
    }
}
