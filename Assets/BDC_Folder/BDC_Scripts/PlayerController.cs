using System.Collections;
using System.Collections.Generic;
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

    //Variable Tir 
    public Camera cam;
    Vector2 mousePos;

    //Variable CaC
    public GameObject TriggerCac;

    //Variable Pause 
    public bool stopTimePause = false;
    public GameObject MenuPause;
    public GameObject MenuOptions;

    public int DamageCaC = 5;
    public int DamageDist = 10;


    void Start()
    {
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");



        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.E))
        {
            cacAttack();
        }

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

        AnimationMilo();
        TurnMilo();

    }

    void AnimationMilo()
    {
        if (movement.y < 0)
        {
            animator.SetBool("IsRunningForwardFace", true);
            animator.SetBool("IsRunningBackwardFace", false);
        }
        else if (movement.y > 0)
        {
            animator.SetBool("IsRunningForwardFace", false);
            animator.SetBool("IsRunningBackwardFace", true);
        }
        else if (movement.y == 0)
        {
            animator.SetBool("IsRunningForwardFace", false);
            animator.SetBool("IsRunningBackwardFace", false);
        }

    }
    void TurnMilo()
    {
        Vector2 orientation = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        float cos = orientation.x;
        float sin = orientation.y;


        if (math.sqrt(3 ) / 2 <= sin)
        {
            animator.SetInteger("Direction", 1);
        }
        if (1 / 2 <= cos && cos < math.sqrt(3 ) / 2 && 1 / 2 <= sin && sin < math.sqrt(3 ) / 2)
        {
            animator.SetInteger("Direction", 2);

        }
        if (math.sqrt(3 ) / 2 <= cos)
        {
            animator.SetInteger("Direction", 3);

        }
        if (1 / 2 <= cos && cos < math.sqrt(3) / 2 && -math.sqrt(3) / 2 <= sin && sin < -1 / 2)
        {
            animator.SetInteger("Direction", 4);

        }
        if (sin < -math.sqrt(3) / 2)
        {
            animator.SetInteger("Direction", 5);

        }
        if (-math.sqrt(3) / 2 <= cos && cos < -1 / 2 && -math.sqrt(3) / 2 <= sin && sin < -1 / 2)
        {
            animator.SetInteger("Direction", 6);

        }
        if (cos <= -math.sqrt(3) / 2)
        {
            animator.SetInteger("Direction", 7);

        }
        if (-math.sqrt(3) / 2 <= cos && cos < -1 / 2 && 1 / 2 <= sin && sin < math.sqrt(3) / 2)
        {
            animator.SetInteger("Direction", 8);

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
        yield return new WaitForSeconds(0.1f);
        TriggerCac.SetActive(false);
        print("Goodbye");
    }




}
