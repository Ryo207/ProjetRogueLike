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

    public float DamageDist;

    PlayerController playerController;
    public GameObject bulletPrefab;
    Damager damagePerBullet;
    public bool shoot;
    bool playOnce;

    //Intervalle de tir
    delegate void shootFunc();
    shootFunc Shoot;
    PlayerController controller;

    [Range(0, 1)]
    public float shootIntervale;

    public float bulletForce = 20f;

    //Mouvement viseur
    Vector2 mousePos;
    Vector2 lookDirection;
    public Transform firePoint;
    public Transform centerPC;
    public GameObject Crosshair;

    //variable Epinard
    ItemCharge itemCharge;
    ItemDetection activeItem;

    private void Start()
    {
        playerController = GameObject.Find("Perso").GetComponent<PlayerController>();
        itemCharge = GetComponent<ItemCharge>();
        activeItem = GetComponentInChildren<ItemDetection>();
        Shoot = DoShoot;
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        LookDirection();
        Shoot();
        strengUp();
        damagePerBullet = bulletPrefab.GetComponent<Damager>();
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
            controller.moveSpeed = 0;
            shoot = true;
            StartCoroutine(nameof(waitShoot));
        }
    }

    IEnumerator waitShoot()
    {
        Shoot = DontShoot;
        yield return new WaitForSeconds(0.15f);
        FindObjectOfType<AudioManager>().Play("Tirer");
        GameObject fireBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        fireBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletForce;
    }

    void strengUp()
    {
        if (Input.GetKeyDown(KeyCode.Space) && activeItem.spinach == true && itemCharge.useActiveItem == true)
        {
            itemCharge.chargesisUsed();
            StartCoroutine(nameof(damageBoostTimer));
        }
    }
    IEnumerator damageBoostTimer()
    {
        DamageDist *= 2;
        yield return new WaitForSeconds(30);
        DamageDist /= 2;

    }

    void DontShoot()
    {
        StartCoroutine(nameof(ShootIntervale));
    }

    IEnumerator ShootIntervale()
    {
        yield return new WaitForSeconds(shootIntervale);
        shoot = false;
        controller.moveSpeed = 8;
        yield return Shoot = DoShoot;
    }
}
