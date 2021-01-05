using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingPhaseManager : MonoBehaviour
{
    [SerializeField]
    PathFinding[] pathfinding;

    [SerializeField]
    EnnemyView[] ennemyColor;
    
    public bool hiveMind;

    private void Start()
    {
        pathfinding = GetComponentsInChildren<PathFinding>();
        hiveMind = false;

        ennemyColor = GetComponentsInChildren<EnnemyView>();
    }

    private void Update()
    {
        DetectHiveMind();
    }

    void DetectHiveMind()
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
