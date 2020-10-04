using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;


    PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Perso").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !playerController.stopTimePause) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
