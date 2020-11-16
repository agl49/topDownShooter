using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//May not need to be mono behavior in future
public class playerHealth : MonoBehaviour, Ihealth
{
    private bool alive = true;
    [SerializeField]
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Returns new health
    public float takeSmallDamage(float dmg)
    {
        currentHealth -= dmg;
        currentHealth = Mathf.Clamp(currentHealth, 0f, 100f);
        if(currentHealth <= 0)
            alive = false;

        return currentHealth;    
    }

    public void setCurrentHealth(float health)
    {
        currentHealth = health;
    }

    public bool isAlive()
    {
        return alive;
    }
}
