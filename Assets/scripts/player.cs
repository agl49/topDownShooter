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
    private UnityEvent<bool> OnDie; 

    [SerializeField]
    private UnityEvent<bool> OnMoving;

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
        if(movement.x != 0 || movement.y != 0)
        {
            OnMoving?.Invoke(true);
        }
        else
        {
            OnMoving?.Invoke(false);
        }
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;

    }

    private void getInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void actDead()
    {
        //Doesn't work...
        movement.x = 0;
        movement.y = 0;
        rb.velocity = Vector2.zero;
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
        OnDie?.Invoke(!myHealth.isAlive());
        Debug.Log("I died");
        Debug.Log("myHealth.isAlive = " + myHealth.isAlive());
        actDead();
    }

}
