using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCrystal : MonoBehaviour
{
    public float delayUntilDestroy = 0.4f;

    public ParticleSystem explosion;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Explosion");

        }
 
    }

    IEnumerator Explosion()
    {
        explosion.Play();
        yield return new WaitForSeconds(delayUntilDestroy);
        explosion.Stop();
        Destroy(gameObject);
    }
}
