using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable Mouvement Perso
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    //Variable Tir 
    public Camera cam;
    Vector2 mousePos;

    void Start()
    {
        
    }

    void Update()
    {
      movement.x =  Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      
        
     mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed );

        rb.velocity = new Vector2(movement.x, movement.y).normalized * moveSpeed;

        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
