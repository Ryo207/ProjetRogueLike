using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_WakeUp : MonoBehaviour
{
    
    public firePoints points;
    public enum firePoints
    {
        One_FP, Two_FP, Three_FP, Four_Fp, Five_Fp, Six_Fp, Seven_Fp, Eight_Fp, Nine_FP, Ten_Fp, 

    }

    public float bulletForce;

    //Intervalle de tir
    delegate void shootFunc();
    shootFunc Shoot;

    public float shootIntervale;

    Vector2 fpDirection;
    public GameObject bulletPrefab;
    public GameObject PremierFirepoint;
    public GameObject DeuxiemeFirepoint;
    public GameObject TroisiemeFirepoint;
    public GameObject QuatrièmeFirepoint;
    public GameObject CinquiemeFirepoint;
    public GameObject SixiemeFirepoint;
    public GameObject SeptiemeFirepoint;
    public GameObject HuitiemeFirepoint;
    public GameObject NeuviemeFirepoint;
    public GameObject DixiemeFirepoint;

    public Transform oneFP;
    public Transform TwoFp;
    public Transform ThreeFp;
    public Transform FourFp;
    public Transform FiveFp;
    public Transform SixFp;
    public Transform SevenFp;
    public Transform EightFp;
    public Transform NineFp;
    public Transform TenFp;
    


    private void Start()
    {
        Shoot = DoShoot;

    }
    private void DoShoot()
    {
        switch (points)
        {
            case firePoints.One_FP:
                fpDirection = (oneFP.transform.position - transform.position).normalized * bulletForce;

                GameObject fireBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                fireBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);

                break;
            case firePoints.Two_FP:
                break;
            case firePoints.Three_FP:
                break;
            case firePoints.Four_Fp:
                break;
            case firePoints.Five_Fp:
                break;
            case firePoints.Six_Fp:
                break;
            case firePoints.Seven_Fp:
                break;
            case firePoints.Eight_Fp:
                break;
            case firePoints.Nine_FP:
                break;
            case firePoints.Ten_Fp:
                break;
            default:
                break;
        }

     //   GameObject fireBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
          //  fireBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
        


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
