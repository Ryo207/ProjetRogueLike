using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private float Timer;
    private bool onTrap;

    [SerializeField]
    Damager damager;
    void Start()
    {
        
    }

    void Update()
    {
        if (onTrap == true)
        {
            Timer += Time.deltaTime;
          
        }

        if (Timer == 1.5f)
        {
            print("Wesh");
            onTrap = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        onTrap = true;
    }


    private void OnCollisionExit2D(Collision2D col)
    {
        onTrap = false;
    }
}