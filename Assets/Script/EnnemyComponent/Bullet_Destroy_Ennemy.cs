using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Destroy_Ennemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall") || (col.gameObject.CompareTag("Player")))
        {
            Destroy(gameObject);
        }
    }
}