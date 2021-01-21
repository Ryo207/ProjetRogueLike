using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Griffe : MonoBehaviour
{
    public GameObject Griffe_Collider;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(nameof(AttackCac));
    }
    public IEnumerator AttackCac()
    {
        yield return new WaitForSeconds(0.1f);
        Griffe_Collider.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Griffe_Collider.SetActive(false);

    }
}
