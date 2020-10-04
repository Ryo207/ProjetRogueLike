using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerLife = 100;

    private void GetDamage(int damage)
    {
        PlayerLife -= damage;
        print(PlayerLife);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EnnemyAttack"))
        {
            GetDamage(col.gameObject.GetComponent<Damager>().Damage());
        }
    }
    private void GetDeath()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (PlayerLife <= 0)
        {
            GetDeath();
        }
    }

}
