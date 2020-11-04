using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform follow;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(follow.position.x, 
                                              follow.position.y,
                                              this.transform.position.z);        
    }
}
