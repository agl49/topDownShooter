using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Maybe change to abstract class?
interface Ihittable
{
    void getHit(float dmg);
    //UnityEvent die { get; set; }
    void die();   
}
