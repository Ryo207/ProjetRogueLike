using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    //Variable CaC
    public GameObject TriggerCac;
    public YT_PCAnimationHandler animHandler;
    float waittime = 1f;
    float time;
    bool combo1;
    bool combo2;
    bool timerStart;
    public ItemsSO weapon;

    void Start()
    {
        timerStart = false;
    }
    void Update()
    {
        if (timerStart == true)
        {
            if (waittime > 0)
            {
                waittime -= Time.deltaTime;
                print(waittime);
            }
            else
            {
                waittime = 1f;
                timerStart = false;
            }
        }
        Attack();
    }
    void Attack()
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
        yield return new WaitForSeconds(weapon.ImpactTime);
        TriggerCac.SetActive(true);
        print("Hello");
        yield return new WaitForSeconds(0.2f);
        TriggerCac.SetActive(false);

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

            animHandler.animator.SetBool("Combo1", false);
            animHandler.animator.SetBool("Combo2", false);
            animHandler.animator.SetBool("Attack", false);
            print("Goodbye");

    }
}
