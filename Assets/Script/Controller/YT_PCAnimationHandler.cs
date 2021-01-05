using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;

public class YT_PCAnimationHandler : MonoBehaviour
{
    public GameObject centerPc;
    public PlayerController controller;
    public PlayerAttack attackScipt;
    public PlayerHealth healtSystem;
    public Animator animator;
    Vector2 mousePos;
 

    // Start is called before the first frame update
    void Start()
    {
        InstantiatePlayerComponents();
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = controller.cam.ScreenToWorldPoint(Input.mousePosition);
        DetectMoving();
        AnimationYAxis();
        AnimationXAxis();
        AttackMilo();
        TurnMilo();
        IsHurt();
        IsDead();

    }

    void InstantiatePlayerComponents()
    {
        controller = GetComponent<PlayerController>();
        attackScipt = GetComponent<PlayerAttack>();
        healtSystem = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = mousePos - controller.rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
    }

    void DetectMoving()
    {
        if (controller.movement.y != 0 ^ controller.movement.x != 0)
        {
            animator.SetBool("Moving", true);
            animator.SetBool("StartTurnAround", false);
        }

        else if (controller.movement.y == 0 && controller.movement.x == 0)
        {
            animator.SetBool("Moving", false);
            animator.SetBool("StartTurnAround", true);
        }
    }
    void AnimationYAxis()
    {
        animator.SetFloat("Vertical", controller.movement.y);

    }
    void AnimationXAxis()
    {
        animator.SetFloat("Horizontal", controller.movement.x);
    }

    void AttackMilo()
    {
        if (Input.GetKeyDown(KeyCode.E) && attackScipt.canAttack == true)
        {
            animator.SetBool("Attack", true);
        }
    }
    void TurnMilo()
    {
        animator.SetFloat("Angle", centerPc.transform.rotation.eulerAngles.z);
    }

    void IsHurt()
    {
        animator.SetBool("IsHurt", healtSystem.isHurt);
    }

    void IsDead()
    {
        animator.SetBool("IsDead", healtSystem.isDead);
    }
}
