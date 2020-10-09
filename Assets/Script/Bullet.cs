using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class Bullet : MonoBehaviour
{
    public Transform firePoint;
    public Transform centerPC;
    public GameObject bulletPrefab;
    public Transform crosshair;
    public GameObject perso;

    public float bulletForce = 20f;

    Vector2 mousePos;
    Vector2 lookDirection;

    PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Perso").GetComponent<PlayerController>();
    }

    void Update()
    {
        LookDirection();

        if (Input.GetButtonDown("Fire1") && !playerController.stopTimePause) 
        {
            Shoot();
        }
    }

    void LookDirection()
    {
        mousePos = playerController.cam.ScreenToWorldPoint(Input.mousePosition);

        lookDirection = mousePos - (Vector2)centerPC.position;
        lookDirection.Normalize();

        float lookAngle;
        lookAngle = Vector2.SignedAngle(Vector2.up, lookDirection);

        centerPC.rotation = Quaternion.Euler(0f, 0f, lookAngle + 90f);
    }

    void Shoot()
    {
        GameObject fireBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        fireBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletForce;

    }
}
