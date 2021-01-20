using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Destroy_Scorpion : MonoBehaviour
{
    public GameObject poisonPuddle;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall") || (col.gameObject.CompareTag("Player")))
        {
            spawnPoisonPuddle();
            Destroy(gameObject);
        }
    }

    public void spawnPoisonPuddle()
    {

        Instantiate(poisonPuddle, transform.position, poisonPuddle.transform.rotation);
    }
}
