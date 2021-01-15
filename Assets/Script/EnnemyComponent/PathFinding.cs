using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathFinding : MonoBehaviour
{


    UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] public Transform[] waypoints;
    Transform Player;
    FightingPhaseManager globalAlert;
    public int currentWaypoint = 0;
    public bool FightingPhase = false;

    public bool isCrystalSpawner;
    public bool isPhantom;

    public GameObject Phantom;

    public float teleportTime = 1.5f;

    private bool isTeleporting = false;

    private int randwaypoint;

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
        if (currentState == EnemyStates.Patrolling) agent.SetDestination(waypoints[currentWaypoint].position);
        StartCoroutine(nameof(TeleportIntervalle));

    }

    void Update()
    {

        if (isCrystalSpawner == false && isPhantom == false)
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

        }
        if (isCrystalSpawner == true)
        {
            agent.isStopped = true;  
        }

        if (FightingPhase == false && isPhantom == false)
        {
            currentState = EnemyStates.Patrolling;
        }

        if (currentState == EnemyStates.Patrolling && FightingPhase == false && isCrystalSpawner == false && isPhantom == false)
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

        if (isPhantom == true && FightingPhase == false && isTeleporting == true)
        {
            Teleport();
            isTeleporting = false;
        }

        if (FightingPhase == true ) 
        {
            globalAlert.hiveMind = true;           
            agent.SetDestination(Player.position);
            agent.stoppingDistance = (Random.Range(5f, 8f));
        }
    }
    private void Teleport()
    {
        randwaypoint = Random.Range(0, waypoints.Length);
        Phantom.transform.position = new Vector2(waypoints[randwaypoint].transform.position.x, waypoints[randwaypoint].transform.position.y);
        StartCoroutine(nameof(TeleportIntervalle));
    }
    IEnumerator TeleportIntervalle()
    {
        yield return new WaitForSeconds(teleportTime);
        isTeleporting = true;
    }
}
 