using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnnemyShoot : MonoBehaviour
{
    [SerializeField]
    PathFinding pathFinding;

    public float bulletForce;

    //Intervalle de tir
    delegate void shootFunc();
    shootFunc Shoot;

    [Range(0, 1)]
    public float shootIntervale;

    Vector2 pCDirection;
    public GameObject bulletPrefab;
    public Transform firePoint;
    Transform perso;

    //Variable animator
    public bool isShooting;

    private void Start()
    {
        Shoot = DoShoot;
        perso = GameObject.Find("CenterPC").GetComponent<Transform>();
    }

    void Update()
    {
        if (pathFinding.FightingPhase == true)
        {
            Shoot();
        }

    }
    private void DoShoot()
    {
        StopCoroutine(nameof(ShootInvervalle));
        isShooting = true;

        pCDirection = (perso.transform.position - transform.position).normalized * bulletForce;
        GameObject fireBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        fireBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(pCDirection.x, pCDirection.y);

        Shoot = dontShoot;

    }

    void dontShoot()
    {
        isShooting = false;
        StartCoroutine(nameof(ShootInvervalle));
    }

    IEnumerator ShootInvervalle()
    {
        yield return new WaitForSeconds(shootIntervale);
        Shoot = DoShoot;
    }
}