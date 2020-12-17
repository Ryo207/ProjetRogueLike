using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{

    public GameObject parryCollider;
    public float parryRadius = 100f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {

            doParry();
            print("La Chancla");

        }
    }

    private void doParry()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll((Vector2)transform.position, parryRadius);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.gameObject.CompareTag("EnnemyAttack"))
            {
                Destroy(collider.gameObject);
                print("LaChanclaDeux");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere((Vector2)transform.position, parryRadius);
    }

}