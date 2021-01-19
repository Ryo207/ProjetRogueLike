using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;
    void Awake() => instance = this;

    //Variable CaC
    public GameObject TriggerCac;
    public YT_PCAnimationHandler animHandler;
    delegate void attackFunc();
    attackFunc attack;
    public float attackIntervale;
    bool combo1;
    bool combo2;
    public float impactTime;
    public bool canAttack;

    public float DamageCaC = 12.5f;

    //variable Epinard
    ItemCharge itemCharge;
    ItemDetection activeItem;

    void Start()
    {
        attack = DoAttack;
        canAttack = true;
        animHandler = GetComponent<YT_PCAnimationHandler>();
        itemCharge = GetComponent<ItemCharge>();
        activeItem = GetComponentInChildren<ItemDetection>();
    }
    void Update()
    {
        attack();
        strengUp();
    }
    void DoAttack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            cacAttack();
        }
    }

    void cacAttack()
    {
        StartCoroutine("cacAttackCoroutine");
    }

    IEnumerator cacAttackCoroutine()
    {
        yield return new WaitForSeconds(impactTime);
        canAttack = false;
        print("Hello");

        yield return new WaitForSeconds(0.1f);

        animHandler.animator.SetBool("Attack", false);
        yield return attack = dontAttack;
        print("Goodbye");

    }

    void dontAttack()
    {
        StartCoroutine(nameof(AttackIntervale));
        Debug.Log("Start Coroutine");
    }

    IEnumerator AttackIntervale()
    {
        yield return new WaitForSeconds(attackIntervale);
        canAttack = true;
        Debug.Log("AttackIntervaleOver");
        yield return attack = DoAttack;
        StopAllCoroutines();
    }

    void strengUp()
    {
        if (Input.GetKeyDown(KeyCode.Space) && activeItem.spinach == true && itemCharge.useActiveItem == true)
        {
            StartCoroutine(nameof(damageBoostTimer));
        }
    }
    IEnumerator damageBoostTimer()
    {
        DamageCaC *= 2;
        yield return new WaitForSeconds(30);
        DamageCaC /= 2;

    }
}




    //Ancienne construction pour un systeme de combo, à retravailler



    /*if (waittime > 0 && Input.GetKey(KeyCode.E) || waittime > 0 && Input.GetKeyDown(KeyCode.E))
    {
        waittime = 1;
        animHandler.animator.SetBool("Combo1", true);
        yield return new WaitForSeconds(weapon.ImpactTime);
        TriggerCac.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        TriggerCac.SetActive(false);

        if (waittime > 0 && Input.GetKey(KeyCode.E) || waittime > 0 && Input.GetKeyDown(KeyCode.E))
        {
            animHandler.animator.SetBool("Combo2", true);
            yield return new WaitForSeconds(weapon.ImpactTime);
            TriggerCac.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            TriggerCac.SetActive(false);
            animHandler.animator.SetBool("Combo1", false);
            animHandler.animator.SetBool("Combo2", false);
            animHandler.animator.SetBool("Attack", false);
        }

        else
        {
            animHandler.animator.SetBool("Combo1", false);
            animHandler.animator.SetBool("Combo2", false);
            animHandler.animator.SetBool("Attack", false);
            print("Goodbye");

        }
    }*/
