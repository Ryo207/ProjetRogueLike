using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingBoss : MonoBehaviour
{
    

    
    UnityEngine.AI.NavMeshAgent agent;
    Transform Player;



    public float minimumRange;
    public float maximumRange;

    public float speed;

    public float timeBetweenState;

    enum EnemyStates
    {
        Patrolling, Jump, AttackCac, Laser
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

    void Update()
    {

  
    }

    private IEnumerator StateManager()
    {
        
                randomStates d = (EnemyStates)(new Random()).Next(0, 4);

        switch (d)
        {
            case EnemyStates.Patrolling:
                break;
            case EnemyStates.Jump:
                break;
            case EnemyStates.AttackCac:
                break;
            case EnemyStates.Laser:
                break;
            default:
                break;
        }
        

    yield return new WaitForSeconds(timeBetweenState);
    } 
}