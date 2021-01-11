using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingPhaseManager : MonoBehaviour
{
    [SerializeField]
    PathFinding[] pathfinding;
    /*[SerializeField]
    EnnemyView[] coneColor;*/
    
    public bool hiveMind;

    private void Start()
    {
        pathfinding = GetComponentsInChildren<PathFinding>();
        //coneColor = GetComponentsInChildren<EnnemyView>();
        hiveMind = false;
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
