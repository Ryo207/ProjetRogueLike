using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    public float EnnemyLife = 100;
    public GameObject item;
    FightingPhaseManager fpManager;

    private void Start()
    {
        fpManager = GetComponentInParent<FightingPhaseManager>();
    }
    private void GetDamage(float damage)
    {
        EnnemyLife -= damage;
        print(EnnemyLife);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PlayerAttack"))
        {

            GetDamage(col.gameObject.GetComponent<Damager>().Damage());
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("PlayerAttack"))
        {

            GetDamage(col.gameObject.GetComponent<Damager>().Damage());
        }
    }

    private void GetDeath()
    {
        Instantiate(item, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (EnnemyLife <= 0)
        {
            fpManager.hiveMind = true;
            GetDeath();
        }
    }

}