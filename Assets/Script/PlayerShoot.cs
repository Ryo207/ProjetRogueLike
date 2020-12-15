using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerShoot : MonoBehaviour
{

    public static PlayerShoot instance;
    void Awake() => instance = this;

    public float DamageDist = 12.5f;

    PlayerController playerController;
    public GameObject bulletPrefab;

    //Intervalle de tir
    delegate void shootFunc();
    shootFunc Shoot;

    [Range(0, 1)]
    public float shootIntervale;

    public float bulletForce = 20f;

    //Mouvement viseur
    Vector2 mousePos;
    Vector2 lookDirection;
    public Transform firePoint;
    public Transform centerPC;
    public GameObject Crosshair;

    private void Start()
    {
        playerController = GameObject.Find("Perso").GetComponent<PlayerController>();
        Shoot = DoShoot;
    }

    void Update()
    {
        LookDirection();
        Shoot();
    }

    void LookDirection()
    {
        mousePos = playerController.cam.ScreenToWorldPoint(Input.mousePosition);
        Crosshair.transform.position = mousePos;

        lookDirection = mousePos - (Vector2)centerPC.position;
        lookDirection.Normalize();

        float lookAngle;
        lookAngle = Vector2.SignedAngle(Vector2.up, lookDirection);

        centerPC.rotation = Quaternion.Euler(0f, 0f, lookAngle + 90f);
    }

    void DoShoot()
    {
        StopCoroutine(nameof(ShootIntervale));

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject fireBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            fireBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletForce;
            Shoot = DontShoot;
        }
    }

    void DontShoot()
    {
        StartCoroutine(nameof(ShootIntervale));
    }

    IEnumerator ShootIntervale()
    {
        yield return new WaitForSeconds(shootIntervale);
       yield return Shoot = DoShoot;
    }
}
