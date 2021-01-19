using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porc_Epiq_Shooting : MonoBehaviour
{
    [SerializeField]
    PathFinding pathFinding;

    public float bulletForce;

    //Intervalle de tir
    delegate void shootFunc();
    shootFunc Shoot;

    [Range(0, 2)]
    public float shootIntervale;

    Vector2 pCDirection;
    public GameObject bulletPrefab;
    public Transform firePoint;
    Transform perso;

    public int numberofBullet;
    private float delayBetweenBullet = 0.2f;

    private bool alreadyShooting;

    private void Start()
    {
        perso = GameObject.Find("CenterPC").GetComponent<Transform>();
    }
    

    private void Update()
    {
        if (pathFinding.FightingPhase == true && alreadyShooting == false)
        {
            StartCoroutine(nameof(DoShoot));
        }
    }

    IEnumerator DoShoot()
    {
        StopCoroutine(nameof(ShootInvervalle));
        alreadyShooting = true;

        for (int i = 0; i < numberofBullet; i++)
        {
            pCDirection = (perso.transform.position - transform.position).normalized * bulletForce;
            GameObject fireBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            fireBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(pCDirection.x, pCDirection.y);
            yield return new WaitForSeconds(delayBetweenBullet);
        }
        StartCoroutine(nameof(ShootInvervalle));

    }

    IEnumerator ShootInvervalle()
    {
        yield return new WaitForSeconds(shootIntervale);
        alreadyShooting = false;

    }
}
