using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIhealth : MonoBehaviour
{
    [SerializeField] private Text healthText;
    
    public void updateHealth(float newHealth)
    {
        healthText.text = newHealth.ToString();
    }
}
