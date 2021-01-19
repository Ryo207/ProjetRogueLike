using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingPhaseCrystal : MonoBehaviour
{
    [SerializeField]
    PathFinding pathFinding;
    void Start()
    {
        pathFinding.FightingPhase = true;
    }

}
