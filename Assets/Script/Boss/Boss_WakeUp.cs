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

    void Start()
    {
        StartCoroutine(nameof(DoShoot));
    }
    IEnumerator DoShoot()
    {
        coroutineCounter++;
   
            fpDirection = (directionPoint.transform.position - transform.position).normalized * bulletForce;

        GameObject fireBulletOne = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation) ;
            fireBulletOne.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
       
          

        /*        break;

            case firePoints.Two_FP:

                fpDirection = (TwoFp.transform.position - transform.position).normalized * bulletForce;

                for (int i = 0; i < numberOfAttackWaves; i++)
                {
                    GameObject fireBulletTwo = Instantiate(bulletPrefab, TwoFp.position, TwoFp.rotation);
                    fireBulletTwo.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
                    yield return new WaitForSeconds(shootIntervale);

                }

                break;

            case firePoints.Three_FP:

                for (int i = 0; i < numberOfAttackWaves; i++)
                {
                    GameObject fireBulletThree = Instantiate(bulletPrefab, ThreeFp.position, ThreeFp.rotation);
                    fireBulletThree.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
                    yield return new WaitForSeconds(shootIntervale);

                }

                break;
            case firePoints.Four_Fp:

                fpDirection = (FourFp.transform.position - transform.position).normalized * bulletForce;

                for (int i = 0; i < numberOfAttackWaves; i++)
                {
                    GameObject fireBulletFour = Instantiate(bulletPrefab, FourFp.position, FourFp.rotation);
                    fireBulletFour.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
                    yield return new WaitForSeconds(shootIntervale);

                }

                break;
            case firePoints.Five_Fp:

                fpDirection = (FiveFp.transform.position - transform.position).normalized * bulletForce;

                for (int i = 0; i < numberOfAttackWaves; i++)
                {
                    GameObject fireBulletFive = Instantiate(bulletPrefab, FiveFp.position, FiveFp.rotation);
                    fireBulletFive.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
                    yield return new WaitForSeconds(shootIntervale);

                }

                break;
            case firePoints.Six_Fp:

                fpDirection = (SixFp.transform.position - transform.position).normalized * bulletForce;

                for (int i = 0; i < numberOfAttackWaves; i++)
                {
                    GameObject fireBulletSix = Instantiate(bulletPrefab, SixFp.position, SixFp.rotation);
                    fireBulletSix.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
                    yield return new WaitForSeconds(shootIntervale);

                }

                break;
            case firePoints.Seven_Fp:


                fpDirection = (SevenFp.transform.position - transform.position).normalized * bulletForce;

                for (int i = 0; i < numberOfAttackWaves; i++)
                {
                    GameObject fireBulletSeven = Instantiate(bulletPrefab, SevenFp.position, SevenFp.rotation);
                    fireBulletSeven.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
                    yield return new WaitForSeconds(shootIntervale);

                }
                break;
            case firePoints.Eight_Fp:


                for (int i = 0; i < numberOfAttackWaves; i++)
                {
                    fpDirection = (EightFp.transform.position - transform.position).normalized * bulletForce;
                    GameObject fireBulletEight = Instantiate(bulletPrefab, EightFp.position, EightFp.rotation);
                    fireBulletEight.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
                    yield return new WaitForSeconds(shootIntervale);

                }
                break;

            case firePoints.Nine_FP:


                for (int i = 0; i < numberOfAttackWaves; i++)
                {
                    fpDirection = (NineFp.transform.position - transform.position).normalized * bulletForce;
                    GameObject fireBulletEight = Instantiate(bulletPrefab, NineFp.position, NineFp.rotation);
                    fireBulletEight.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
                    yield return new WaitForSeconds(shootIntervale);


                }
                break;

            case firePoints.Ten_Fp:
                for (int i = 0; i < numberOfAttackWaves; i++)
                {
                    fpDirection = (NineFp.transform.position - transform.position).normalized * bulletForce;
                    GameObject fireBulletEight = Instantiate(bulletPrefab, NineFp.position, NineFp.rotation);
                    fireBulletEight.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
                    yield return new WaitForSeconds(shootIntervale);


                }
                break;

            case firePoints.Eleven_FP:

                for (int i = 0; i < numberOfAttackWaves; i++)
                {
                    fpDirection = (ElevenFp.transform.position - transform.position).normalized * bulletForce;
                    GameObject fireBulletEight = Instantiate(bulletPrefab, ElevenFp.position, NineFp.rotation);
                    fireBulletEight.GetComponent<Rigidbody2D>().velocity = new Vector2(fpDirection.x, fpDirection.y);
                    yield return new WaitForSeconds(shootIntervale);

                }
                break;
            default:
                break; */
                        yield return new WaitForSeconds(shootIntervale);
        if (coroutineCounter <= numberOfAttackWaves)
        {
            StartCoroutine(nameof(DoShoot));


        }
    }



    }

    /*
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
    */

