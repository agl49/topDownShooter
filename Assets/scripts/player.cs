using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class player : MonoBehaviour, Ihittable
{
    // Start is called before the first frame update
    [SerializeField]
    private float maxHealth = 100f;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float speed = 5f;
    
    private Vector2 movement;
    private Vector2 mousePos;

    private Ihealth myHealth;

    [SerializeField]
    private UnityEvent OnGetHit;
    
    [SerializeField]
    private UnityEvent OnDie; 

    // Start is called before the first frame update
    void Start()
    {
        myHealth = gameObject.GetComponent<Ihealth>();
        myHealth.setCurrentHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       getInput();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;

    }

    public void getHit(float dmg)
    {
        myHealth.takeSmallDamage(dmg);
        //OnGetHit?.Invoke();
        if(!myHealth.isAlive())
            die();

        Debug.Log("hit");    
    }

    public void die()
    {
        //OnDie?.Invoke();
        Debug.Log("I died");
    }

    private void getInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
