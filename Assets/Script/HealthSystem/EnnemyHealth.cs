using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    public int EnnemyLife = 100;
    public GameObject item;


    private void Update()
    {
        if (EnnemyLife <= 0)
        {
            GetDeath();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PlayerAttack"))
        {

            GetDamage(col.gameObject.GetComponent<Damager>().Damage());
        }
    }

    private void GetDamage(int damage)
    {
        EnnemyLife -= damage;
        print(EnnemyLife);

    }
   
    private void GetDeath()
    {
        Instantiate(item, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

  

}