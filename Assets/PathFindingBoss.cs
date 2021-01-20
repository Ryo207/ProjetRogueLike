using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingBoss : MonoBehaviour
{
    
    /*

    
    UnityEngine.AI.NavMeshAgent agent;
    Transform Player;
    public int currentWaypoint = 0;
    public bool FightingPhase = false;

    public bool isCrystalSpawner;
    public bool isPhantom;
    public bool isPillar;

    public GameObject Phantom;

    public float teleportTime = 1.5f;

    private bool isTeleporting = false;

    private int randwaypoint;

    public float minimumRange;
    public float maximumRange;

    public float speed;

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
        agent.speed = speed;
        agent.updateUpAxis = false;

        if (currentState == EnemyStates.Patrolling && isPhantom == false)
        {

            agent.SetDestination(waypoints[currentWaypoint].position);
        }
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



        if (isPhantom == true && FightingPhase == false && isTeleporting == true)
        {
            Teleport();
        }

        if (FightingPhase == true)
        {
            globalAlert.hiveMind = true;
            agent.SetDestination(Player.position);
            agent.stoppingDistance = (Random.Range(minimumRange, maximumRange));
        }
    }
    private void Teleport()
    {
        isTeleporting = false;
        randwaypoint = Random.Range(0, waypoints.Length);
        Phantom.transform.position = new Vector2(waypoints[randwaypoint].transform.position.x, waypoints[randwaypoint].transform.position.y);
        StartCoroutine(nameof(TeleportIntervalle));
    }
    IEnumerator TeleportIntervalle()
    {
        yield return new WaitForSeconds(teleportTime);
        isTeleporting = true;
    }

*/

    }