using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Laser : MonoBehaviour
{
    public GameObject Laser_collider;
    public float durationOfTheLaser;
    void Start()
    {
        StartCoroutine(nameof(DoLaser));
    


    }

    public IEnumerator DoLaser()
    {
        yield return new WaitForSeconds(0.1f);
        Laser_collider.SetActive(true);
        yield return new WaitForSeconds(durationOfTheLaser);
        Laser_collider.SetActive(false);

    }
}
