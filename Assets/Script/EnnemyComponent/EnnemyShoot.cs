using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyShoot : MonoBehaviour
{
    [SerializeField]
    PathFinding pathFinding;

    public float bulletForce;

    public GameObject bulletPrefab;
    public GameObject player;
    public Transform firePoint;

    void Update()
    {
        if (pathFinding.FightingPhase == true)
        {
            Shoot();
        }
    
    }
    private void Shoot()
    {
        GameObject fireBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        fireBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletForce;

    }
}