using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingPhaseManager : MonoBehaviour
{
    [SerializeField]
    PathFinding[] pathfinding;
    
    public bool hiveMind;

    private void Start()
    {
        pathfinding = GetComponentsInChildren<PathFinding>();
        hiveMind = false;
    }

    private void Update()
    {
        if (hiveMind == true)
        {
            for (int i = 0; i < pathfinding.Length; i++)
            {
                pathfinding[i].FightingPhase = true;
            }
        }
    }
}
