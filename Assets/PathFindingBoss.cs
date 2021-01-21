using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingBoss : MonoBehaviour
{
    

    
    UnityEngine.AI.NavMeshAgent agent;
    Transform Player;

    [SerializeField]
    Boss_WakeUp wakeUp;

    [SerializeField]
    Boss_Griffe griffe;

    [SerializeField]
    Boss_Laser laser;


    public float minimumRange;
    public float maximumRange;

    public float speed;

    public float timeBetweenState;

    float rand;

    enum EnemyStates
    {
        Patrolling, Jump, AttackCac, Laser, Awake 
    }

    [SerializeField] EnemyStates currentState;

    void Start()
    {
      
        Player = GameObject.Find("Perso").GetComponent<Transform>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.speed = speed;
        agent.updateUpAxis = false;
        StartCoroutine(nameof(StateManager));
        


    }

    void FixedUpdate()
    {

        if (currentState == EnemyStates.Patrolling && currentState == EnemyStates.AttackCac)
        {
            agent.SetDestination(Player.position);
            agent.stoppingDistance = (Random.Range(minimumRange, maximumRange));


        }
    }

    private IEnumerator StateManager()
    {
        yield return new WaitForSeconds(timeBetweenState);
        currentState = EnemyStates.Patrolling;
    
        ChooseState();
        


    } 

    private void ChooseState()
    {

        switch (currentState)
        {
            case EnemyStates.Patrolling:
              
                StartCoroutine(nameof(StateManager));
                print("PatrollingEffectué");
                break;
            case EnemyStates.Jump:
                break;
            case EnemyStates.AttackCac:
                print("AttackCacEffectué");
                break;
            case EnemyStates.Laser:

                break;
            case EnemyStates.Awake:
                wakeUp.StartCoroutine(nameof(wakeUp.DoShoot));
                rand = Random.Range(0, 1f);
                StartCoroutine(nameof(StateManager));
                print("AwakeEffectué");
                break;
                
            default:
                break;
        }


    }
}