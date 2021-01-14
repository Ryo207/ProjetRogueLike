using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YT_EnnemiAnimHandler : MonoBehaviour
{
    public Animator EnnemiAnnimator;
    public GameObject centerEnnemy;
    public EnnemyHealth health;
    public EnnemyShoot shoot;

    // Update is called once per frame
    private void Start()
    {
        EnnemiAnnimator = GetComponent<Animator>();
        health = GetComponent<EnnemyHealth>();
        shoot = GetComponent<EnnemyShoot>();
    }

    void Update()
    {
        TurnEnnemi();
        Gethit();
        GetShoot();
    }

    void TurnEnnemi()
    {
        EnnemiAnnimator.SetFloat("Angle", centerEnnemy.transform.rotation.eulerAngles.z);
    }

    void Gethit()
    {
        EnnemiAnnimator.SetBool("Hit", health.isHit);
    }

    void GetShoot()
    {
        EnnemiAnnimator.SetBool("Shoot", shoot.isShooting);
    }
}
