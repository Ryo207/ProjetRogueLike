using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int life = 100;

    private void GetDamage(int damage)
    {
        life -= damage;
        print(life);

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
        if (life <= 0)
        {
            GetDeath();
        }
    }

}
