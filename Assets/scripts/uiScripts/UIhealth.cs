using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIhealth : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    
    public void updateHealth(float newHealth)
    {
        healthText.text = newHealth.ToString();
    }
}
