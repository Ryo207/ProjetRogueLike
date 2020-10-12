using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingPhaseManager : MonoBehaviour
{
    [SerializeField]
    PathFinding pathfinding;
    public bool hiveMind;

    private void Start()
    {
        hiveMind = false;
    }

    private void Update()
    {
        if (hiveMind == true)
        {
            pathfinding.FightingPhase = true;
        }
        
    }
}
