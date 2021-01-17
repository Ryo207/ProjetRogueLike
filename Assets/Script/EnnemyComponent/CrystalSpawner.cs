using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    [SerializeField]
    PathFinding pathFinding;

    public GameObject Crystal;
    public Transform[] firePoint;
    private int randfp;

    public GameObject fpManager;

    [Range(0, 5)]
    public float shootIntervale;
    private bool alreadyShooting;


    private void Start()
    {

    }


    private void Update()
    {
        if (pathFinding.FightingPhase == true && alreadyShooting == false)
        {
            SpawnCrystal();
        }
    }


    private void SpawnCrystal()
    {

        randfp = Random.Range(0, firePoint.Length);

        StopCoroutine(nameof(ShootInvervalle));
        alreadyShooting = true;
        Instantiate(Crystal, firePoint[randfp].position, firePoint[randfp].rotation, fpManager.transform) ; 
        StartCoroutine(nameof(ShootInvervalle));

    }

    IEnumerator ShootInvervalle()
    {
        yield return new WaitForSeconds(shootIntervale);
        alreadyShooting = false;
    }

}

