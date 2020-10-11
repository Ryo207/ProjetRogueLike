using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyView : MonoBehaviour
{
    [SerializeField]
    PathFinding pathFinding;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>())
        {
            pathFinding.FightingPhase = true;
            print("Hello Sir");
        }
    }
}