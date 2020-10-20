using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    void Awake() => instance = this;

    //Variable Mouvement Perso
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public YT_PCAnimationHandler animHandler;
    public Vector2 movement;

    public Camera cam;

    //Variable CaC
    public GameObject TriggerCac;

    public int DamageCaC = 5;
    public int DamageDist = 10;
    public bool closeToLever;

    public LeverTrigger levertrigger;


    void Start()
    {
    }

    void Update()
    {
        Movement();
        Attack();
        ActivateLever();
    }

    void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x, movement.y).normalized * moveSpeed;
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            cacAttack();
        }
    }

    void cacAttack()
    {
        StartCoroutine("cacAttackCoroutine");
    }

    void ActivateLever()
    {
        if (Input.GetKeyDown(KeyCode.T) && closeToLever == true)
        {
            if (levertrigger.lightMilestone == false)
            {
                levertrigger.BlueLight();
            }
            else if (levertrigger.lightMilestone == true)
            {
                levertrigger.RedLight();
            }
        }
    }

    IEnumerator cacAttackCoroutine()
    {
        TriggerCac.SetActive(true);
        print("Hello");
        yield return new WaitForSeconds(0.5f);
        TriggerCac.SetActive(false);
        animHandler.animator.SetBool("Attack", false);
        print("Goodbye");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<LeverTrigger>())
        {
            closeToLever = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<LeverTrigger>())
        {
            closeToLever = false;
        }
    }
}
