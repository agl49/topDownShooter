using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // this function will check for the exit door
    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Exit")
        {
            Time.timeScale = 0f;
        }
    }
}
