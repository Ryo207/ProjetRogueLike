using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathFinding : MonoBehaviour
{


    UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] public Transform[] waypoints;
    public Transform Player;

    public int currentWaypoint = 0;
    public bool FightingPhase = false;
    public float ShootingDistance;

    enum EnemyStates
    {
        Patrolling,
    }

    [SerializeField] EnemyStates currentState;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        if (currentState == EnemyStates.Patrolling) agent.SetDestination(waypoints[currentWaypoint].position);
    }

    void Update()
    {
        if (FightingPhase == false)
        {
            currentState = EnemyStates.Patrolling;
        }

        if (currentState == EnemyStates.Patrolling && FightingPhase == false)
        {
            if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) <= 0.6f)
            {
                currentWaypoint++;
                if (currentWaypoint == waypoints.Length)
                {
                    currentWaypoint = 0;
                }
                agent.SetDestination(waypoints[currentWaypoint].position);

            }
        }


        if (FightingPhase == true ) 
        {
            agent.SetDestination(Player.position);
            agent.stoppingDistance = (Random.Range(5f, 8f));
        }
        
    } 
}
 