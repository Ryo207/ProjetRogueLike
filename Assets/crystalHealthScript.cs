using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalHealthScript : MonoBehaviour
{
    public float EnnemyLife;
    public int normalLife;
    public GameObject item;
    FightingPhaseManager fpManager;
    EnnemyViewCrystalSpawner ennemyColor;
    public LeverTrigger roomColor;
    bool bonusGiven;
    public bool isHit;


    private void Start()
    {
        fpManager = GetComponentInParent<FightingPhaseManager>();
        ennemyColor = GetComponentInChildren<EnnemyViewCrystalSpawner>();
        roomColor = GameObject.Find("Lever").GetComponent<LeverTrigger>();
        bonusGiven = true;
    }
    private void Update()
    {
        if (EnnemyLife <= 0)
        {
            fpManager.hiveMind = true;
            GetDeath();
        }

        if (isHit == true)
        {
            isHit = false;
        }
    }
    public void GetDamage(float damage)
    {
        isHit = true;
        EnnemyLife -= damage;
        print(EnnemyLife);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PlayerAttack"))
        {
            GetDamage(col.gameObject.GetComponent<Damager>().Damage());
            fpManager.hiveMind = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("PlayerAttack"))
        {
            GetDamage(col.gameObject.GetComponent<Damager>().Damage());
            fpManager.hiveMind = true;
        }
    }

    private void GetDeath()
    {
        Instantiate(item, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
