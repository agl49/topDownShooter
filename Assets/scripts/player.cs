using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class player : MonoBehaviour, Ihittable
{
    // Start is called before the first frame update
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    [SerializeField] private float speed = 5f;
    private Vector2 movement;
    private Vector2 mousePos;
    private Ihealth myHealth;
    private bool enableInput = true;
    private bool enableMove = true;

    [SerializeField] private UnityEvent<float> OnGetHit;
    
    [SerializeField] private UnityEvent<bool> OnDie; 

    [SerializeField] private UnityEvent<bool> OnMoving;

    // Start is called before the first frame update
    void Awake()
    {
        myHealth = gameObject.GetComponent<Ihealth>();
    }

    void Start()
    {
        myHealth.setCurrentHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       getInput();
    }

    void FixedUpdate()
    {
        move();
        lookWithMouse();

    }

    private void move()
    {
        //This is not the best way to handle death but
        //is should be the fastest.
        if(enableMove)
        {
            if(movement.x != 0 || movement.y != 0)
            {
                OnMoving?.Invoke(true);
            }
            else
            {
                OnMoving?.Invoke(false);
            }

            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    private void lookWithMouse()
    {
        if(enableMove)
        {
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

            rb.rotation = angle;
        }
    }

    private void getInput()
    {
        if(enableInput)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void getHit(float dmg)
    {
        float newHealth = myHealth.takeSmallDamage(dmg);
        OnGetHit?.Invoke(newHealth);
        if(!myHealth.isAlive())
            die();

        Debug.Log("hit");    
    }

    public void stopMovement()
    {
        enableMove = false;
    }

    public void stopInput()
    {
        enableInput = false;
    }

    public void die()
    {
        OnDie?.Invoke(!myHealth.isAlive());
        Debug.Log("I died");
        Debug.Log("myHealth.isAlive = " + myHealth.isAlive());
    }
}
