using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    void Awake() => instance = this;

    //Variable Mouvement Perso
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    //Variable Tir 
    public Camera cam;
    Vector2 mousePos;

    //Variable CaC
    public GameObject TriggerCac;

    //Variable Pause 
    public bool stopTimePause = false;
    public GameObject MenuPause;
    public GameObject MenuOptions;
    
    public int DamageCaC = 5 ;
    public int DamageDist = 10;

    public bool closeToLever;

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
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (closeToLever == true)
            {
                print("Nique la bac");
            }

        }
       

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x, movement.y).normalized * moveSpeed;

        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
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
