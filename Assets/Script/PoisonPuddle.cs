using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPuddle : MonoBehaviour
{
    public GameObject TriggerPoisonPuddle;

    public float delayUntilNextDamage;
    public float delayUntilDestroy;

    private IEnumerator PoisonPuddlent;
    private IEnumerator DestroyPoisonPuddlent;


    void Start()
    {

        PoisonPuddlent = PoisonPuddleCoroutine();
        DestroyPoisonPuddlent = DestroyPoisonPuddle();

        StartCoroutine(PoisonPuddlent);
        StartCoroutine(DestroyPoisonPuddlent);


    }

     IEnumerator PoisonPuddleCoroutine()
    {

        TriggerPoisonPuddle.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        TriggerPoisonPuddle.SetActive(false);

        yield return new WaitForSeconds(delayUntilNextDamage);

        TriggerPoisonPuddle.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        TriggerPoisonPuddle.SetActive(false);

        yield return new WaitForSeconds(delayUntilNextDamage);

        TriggerPoisonPuddle.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        TriggerPoisonPuddle.SetActive(false);

    }

    IEnumerator DestroyPoisonPuddle()
    {

        yield return new WaitForSeconds(delayUntilDestroy);
        Destroy(gameObject);

    }


}
