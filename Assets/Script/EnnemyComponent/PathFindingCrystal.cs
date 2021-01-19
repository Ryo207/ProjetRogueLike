using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingCrystal : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent agent;
    Transform Player;
    FightingPhaseManager globalAlert;
    public bool FightingPhase = false;

    enum EnemyStates
    {
        Patrolling,
    }

    [SerializeField] EnemyStates currentState;

    void Start()
    {
        globalAlert = GetComponentInParent<FightingPhaseManager>();
        Player = GameObject.Find("Perso").GetComponent<Transform>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {


        if (FightingPhase == true)
        {
            globalAlert.hiveMind = true;
            agent.SetDestination(Player.position);
            agent.stoppingDistance = (Random.Range(5f, 8f));
        }

    }
}

