using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapDestructor : MonoBehaviour
{
    [SerializeField]
    PathFinding pathFinding;

    void Start()
    {

    }

    void Update()
    {
        if (pathFinding.FightingPhase == true)
        {
            Destroy(gameObject);
        }
    }
}