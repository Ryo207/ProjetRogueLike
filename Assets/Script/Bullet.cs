using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject crosshair;
    public GameObject perso;

    public float bulletForce = 20f;

    Vector2 mousePos;
    Vector2 persoPos;

    PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Perso").GetComponent<PlayerController>();
    }
    void Update()
    {
        persoPos = new Vector2(perso.transform.position.x, perso.transform.position.y);
        mousePos = playerController.cam.ScreenToWorldPoint(Input.mousePosition);
        crosshair.transform.position = mousePos;

        if (Input.GetButtonDown("Fire1") && !playerController.stopTimePause) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(mousePos * bulletForce, ForceMode2D.Impulse);

    }
}
