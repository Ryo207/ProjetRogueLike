using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    public float EnnemyLife;
    public int normalLife;
    public GameObject item;
    FightingPhaseManager fpManager;
    EnnemyView ennemyColor;
    public LeverTrigger roomColor;
    bool bonusGiven;
    public bool isHit;


    private void Start()
    {
        fpManager = GetComponentInParent<FightingPhaseManager>();
        ennemyColor = GetComponentInChildren<EnnemyView>();
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

        ColorBomb();
        CheckColor();
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

    void CheckColor()
    {
        if (ennemyColor.isRed == true && roomColor.lights[0].color == roomColor.red && bonusGiven == true)
        {
            bonusGiven = false;
            EnnemyLife *= 1.35f;
        }

        else if (ennemyColor.isRed == true && roomColor.lights[0].color == roomColor.blue && EnnemyLife > normalLife)
        {
            bonusGiven = true;
            EnnemyLife = normalLife;
        }

        if (ennemyColor.isBlue == true && roomColor.lights[0].color == roomColor.blue && bonusGiven == true)
        {
            bonusGiven = false;
            EnnemyLife *= 1.35f;
        }

        else if (ennemyColor.isBlue == true && roomColor.lights[0].color == roomColor.red && EnnemyLife > normalLife)
        {
            bonusGiven = true;
            EnnemyLife = normalLife;
        }
    }

    private void GetDeath()
    {
        Instantiate(item, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void ColorBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ennemyColor.isRed == true && roomColor.lights[0].color == roomColor.blue)
            {
                ennemyColor.isBlue = true;
                ennemyColor.isRed = false;
            }

            if (ennemyColor.isBlue == true && roomColor.lights[0].color == roomColor.red)
            {
                ennemyColor.isRed = true;
                ennemyColor.isBlue = false;
            }
        }
    }

}