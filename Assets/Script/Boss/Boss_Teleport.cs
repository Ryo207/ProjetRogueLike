using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Teleport : MonoBehaviour
{
    private Transform PC;
    public int delayBeforeImpact;
    public GameObject Boss;

    
    void Update()
    {

        StartCoroutine(nameof(DoTeleport));

    }

    IEnumerator DoTeleport()
    {

      //  GameObject().
        Instantiate(Boss, PC.transform.position, PC.transform.rotation);
        yield return new WaitForSeconds(delayBeforeImpact);


    }
}
