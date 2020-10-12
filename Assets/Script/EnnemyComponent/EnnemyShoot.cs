﻿using System.Collections;
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

    Vector2 pcPos;
    Vector2 pCDirection;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform perso;

    private void Start()
    {
        Shoot = DoShoot;
    }

    void Update()
    {

        if (pathFinding.FightingPhase == true)
        {
            Shoot();
        }

    }

    /*void ShootDirection()
    {
        pCDirection = (Vector2)perso.position - (Vector2)centerEnnemy.position;
        pCDirection.Normalize();

        float shootAngle;
        shootAngle = Vector2.SignedAngle(Vector2.up, pCDirection);

        centerEnnemy.rotation = quaternion.Euler(0f, 0f, shootAngle + 90);
    }*/

    private void DoShoot()
    {
        StopCoroutine(nameof(ShootInvervalle));

        pCDirection = (perso.transform.position - transform.position).normalized * bulletForce;
        GameObject fireBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        fireBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(pCDirection.x, pCDirection.y);

        Shoot = dontShoot;

    }

    void dontShoot()
    {
        StartCoroutine(nameof(ShootInvervalle));
    }

    IEnumerator ShootInvervalle()
    {
        yield return new WaitForSeconds(shootIntervale);
        Shoot = DoShoot;
    }
}