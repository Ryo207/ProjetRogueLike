using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Griffe : MonoBehaviour
{
    public GameObject Griffe_Collider;
   

    public IEnumerator AttackCac()
    {
        yield return new WaitForSeconds(0.1f);
        Griffe_Collider.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Griffe_Collider.SetActive(false);

    }
}
