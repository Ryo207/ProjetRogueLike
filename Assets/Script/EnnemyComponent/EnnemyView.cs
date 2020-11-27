using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Animations;

public class EnnemyView : MonoBehaviour
{
    [SerializeField]
    PathFinding pathFinding;

    [SerializeField]
    FightingPhaseManager fpManager;

    [SerializeField]
    GameEvent TilemapDestructor;

    public Transform ennemyCenter;
    public Transform pC;
    public float speed = 5f;

    private void FixedUpdate()
    {
        detectionDirection();
    }

    void detectionDirection()
    {
        if (pathFinding.FightingPhase == false)
        {
            Vector2 detectionDirection = pathFinding.waypoints[pathFinding.currentWaypoint].position - ennemyCenter.position;
            detectionDirection.Normalize();

            float detectionAngle = Vector2.SignedAngle(Vector2.up, detectionDirection);

            Quaternion rotation = Quaternion.AngleAxis(detectionAngle, Vector3.forward);

            ennemyCenter.rotation = Quaternion.Slerp(ennemyCenter.rotation, rotation, speed * Time.deltaTime);

            //ennemyCenter.rotation = quaternion.Euler(0f, 0f, detectionAngle);
           
            Debug.Log(detectionAngle);
        }

        if (pathFinding.FightingPhase == true)
        {
            Vector2 targetDirection = pC.position - ennemyCenter.position;
            targetDirection.Normalize();

            float centerAngle = Vector2.SignedAngle(Vector2.up, targetDirection);

            ennemyCenter.rotation = Quaternion.Euler(0f, 0f, centerAngle);
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>())
        {
            pathFinding.FightingPhase = true;
            fpManager.hiveMind = true;
            print("Hello Sir");
            TilemapDestructor.Raise();
        }
    }
}