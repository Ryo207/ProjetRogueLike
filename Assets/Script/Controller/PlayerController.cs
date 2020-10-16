﻿using System.Collections;
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
    Vector2 movement;
    public Animator animator;
    //Variable bullets
    public GameObject firePoint;

    //Variable Tir 
    public Camera cam;
    Vector2 mousePos;

    //Variable CaC
    public GameObject TriggerCac;

    public bool stopTimePause;
    public GameObject MenuPause;
    public GameObject MenuOptions;

    public int DamageCaC = 5;
    public int DamageDist = 10;
    public bool closeToLever;

    public LeverTrigger levertrigger;


    void Start()
    {
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuPause.activeSelf ^ MenuOptions.activeSelf)
            {
                MenuPause.SetActive(false);
                MenuOptions.SetActive(false);
                stopTimePause = false;
            }
            else
            {
                MenuPause.SetActive(true);
                stopTimePause = true;
            }
        }

        if (stopTimePause == true)
        {
            Time.timeScale = 0;
        }

        if (stopTimePause == false)
        {
            Time.timeScale = 1;

        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.E))
        {
            cacAttack();
        }

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

        AnimationYAxis();
        AnimationXAxis();
        TurnMilo();
        DetectMoving();
        AttackMilo();

    }

    void DetectMoving()
    {
        if (movement.y != 0 ^ movement.x != 0)
        {
            animator.SetBool("Moving", true);
            animator.SetBool("StartTurnAround", false);
        }

       else if (movement.y == 0 && movement.x == 0)
       {
            animator.SetBool("Moving", false);
            animator.SetBool("StartTurnAround", true);
        }
    }

    void AnimationYAxis()
    {

        if (movement.y == 0)
        {
            animator.SetFloat("Vertical", 0);
        }

        else if (movement.y < 0)
        {
            animator.SetFloat("Vertical", -1);
            animator.SetBool("StartTurnAround", false);
        }

        else if (movement.y > 0)
        {
            animator.SetFloat("Vertical", 1);
            animator.SetBool("StartTurnAround", false);
        }

    }
    void AnimationXAxis() 
    {

        if (movement.x == 0)
        {

            animator.SetFloat("Horizontal", 0);
        }

        else if (movement.x < 0)
        {

            animator.SetFloat("Horizontal", -1);
        }

        else if (movement.x > 0)
        {

            animator.SetFloat("Horizontal", 1);
        }
    }

    void AttackMilo()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("Attack", true);
        }
    }
    void TurnMilo()
    {

        Vector2 orientation = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        float cos = orientation.x;
        float sin = orientation.y;


        if (math.sqrt(3 ) / 2 <= sin)
        {
            animator.SetFloat("LookVertical", 1f);
            animator.SetFloat("LookHorizontal", 0f);
        }
        else if (1 / 2 <= cos && cos < math.sqrt(3 ) / 2 && 1 / 2 <= sin && sin < math.sqrt(3 ) / 2)
        {
            animator.SetFloat("LookVertical", 0.75f);
            animator.SetFloat("LookHorizontal", 0.75f);

        }
        else if (math.sqrt(3 ) / 2 <= cos)
        {
            animator.SetFloat("LookVertical", 0f);
            animator.SetFloat("LookHorizontal", 1f);

        }
        else if (1 / 2 <= cos && cos < math.sqrt(3) / 2 && -math.sqrt(3) / 2 <= sin && sin < -1 / 2)
        {
            animator.SetFloat("LookVertical", -0.75f);
            animator.SetFloat("LookHorizontal", 0.75f);

        }
        else if (sin < -math.sqrt(3) / 2)
        {
            animator.SetFloat("LookVertical", -1f);
            animator.SetFloat("LookHorizontal", 0f);

        }
        else if (-math.sqrt(3) / 2 <= cos && cos < -1 / 2 && -math.sqrt(3) / 2 <= sin && sin < -1 / 2)
        {
            animator.SetFloat("LookVertical", -0.75f);
            animator.SetFloat("LookHorizontal", -0.75f);

        }
        else if (cos <= -math.sqrt(3) / 2)
        {
            animator.SetFloat("LookVertical", 0f);
            animator.SetFloat("LookHorizontal", -1f);

        }
        else if (-math.sqrt(3) / 2 <= cos && cos < -1 / 2 && 1 / 2 <= sin && sin < math.sqrt(3) / 2)
        {
            animator.SetFloat("LookVertical", 0.75f);
            animator.SetFloat("LookHorizontal", -0.75f);

        }
        //print(animator.GetInteger("Direction"));
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x, movement.y).normalized * moveSpeed;

        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
    }


    void cacAttack()
    {
        StartCoroutine("cacAttackCoroutine");
    }

    IEnumerator cacAttackCoroutine()
    {
        TriggerCac.SetActive(true);
        print("Hello");
        yield return new WaitForSeconds(0.5f);
        TriggerCac.SetActive(false);
        animator.SetBool("Attack", false);


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
