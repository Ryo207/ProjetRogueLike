using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_WakeUp : MonoBehaviour
{
     

    public float bulletForce;

    //Intervalle de tir
    delegate void shootFunc();
    shootFunc Shoot;

    public float shootIntervale;

    Vector2 fpDirection;
    public GameObject bulletPrefab;

    public Transform directionPoint;
  

    public bool isShooting;

    public int numberOfAttackWaves;

    private int coroutineCounter = 0;

   
    public IEnumerator DoShoot()
    {
        coroutineCounter++;
   
            fpDirection = (directionPoint.transform.position - transform.position).normalized * bulletForce;

        GameObject fireBulletOne = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation) ;
            fireBulletOne.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
       
          

                        yield return new WaitForSeconds(shootIntervale);
        if (coroutineCounter <= numberOfAttackWaves)
        {
            StartCoroutine(nameof(DoShoot));


        }
    }



    }



