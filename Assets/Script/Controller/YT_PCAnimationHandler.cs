using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;

public class YT_PCAnimationHandler : MonoBehaviour
{
    public PlayerController controller;
    public Animator animator;
    Vector2 mousePos;
 

    // Start is called before the first frame update
    void Start()
    {
        
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

        if (controller.movement.y == 0)
        {
            animator.SetFloat("Vertical", 0);
        }

        else if (controller.movement.y < 0)
        {
            animator.SetFloat("Vertical", -1);
            animator.SetBool("StartTurnAround", false);
        }

        else if (controller.movement.y > 0)
        {
            animator.SetFloat("Vertical", 1);
            animator.SetBool("StartTurnAround", false);
        }

    }
    void AnimationXAxis()
    {

        if (controller.movement.x == 0)
        {

            animator.SetFloat("Horizontal", 0);
        }

        else if (controller.movement.x < 0)
        {

            animator.SetFloat("Horizontal", -1);
        }

        else if (controller.movement.x > 0)
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


        if (math.sqrt(3) / 2 <= sin)
        {
            animator.SetFloat("LookVertical", 1f);
            animator.SetFloat("LookHorizontal", 0f);
        }
        else if (1 / 2 <= cos && cos < math.sqrt(3) / 2 && 1 / 2 <= sin && sin < math.sqrt(3) / 2)
        {
            animator.SetFloat("LookVertical", 0.75f);
            animator.SetFloat("LookHorizontal", 0.75f);

        }
        else if (math.sqrt(3) / 2 <= cos)
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
    }
}
