using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Animations;
using UnityEngine.Experimental.Rendering.Universal;

public class EnnemyView : MonoBehaviour
{
    [SerializeField]
    public bool isRed;
    public bool isBlue;

    [SerializeField]
    FightingPhaseManager fpManager;


    public Light2D ennemyDetectionLight;
    public Color blue;
    public Color red;

    [SerializeField]
    PathFinding pathFinding;

    [SerializeField]
    GameEvent TilemapDestructor;


    public Transform ennemyCenter;
    public Transform pC;
    public float speed = 5f;


    public void Start()
    {
        ennemyDetectionLight = GetComponent<Light2D>();
        fpManager = FightingPhaseManager.instance;
    }

    private void FixedUpdate()
    {
        detectionDirection();
        checkColor();
    }

    void detectionDirection()
    {
        if (pathFinding.isCrystalSpawner == false)
        {
            if (pathFinding.FightingPhase == false)
            {
                Vector2 detectionDirection = pathFinding.waypoints[pathFinding.currentWaypoint].position - ennemyCenter.position;
                detectionDirection.Normalize();

                float detectionAngle = Vector2.SignedAngle(Vector2.up, detectionDirection);

                Quaternion rotation = Quaternion.AngleAxis(detectionAngle, Vector3.forward);

                ennemyCenter.rotation = Quaternion.Slerp(ennemyCenter.rotation, rotation, speed * Time.deltaTime);
            }

            if (pathFinding.FightingPhase == true)
            {
                Vector2 targetDirection = pC.position - ennemyCenter.position;
                targetDirection.Normalize();

                float centerAngle = Vector2.SignedAngle(Vector2.up, targetDirection);

                ennemyCenter.rotation = Quaternion.Euler(0f, 0f, centerAngle);
            }
        }
       
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            pathFinding.FightingPhase = true;
            print("Hello Sir");
            TilemapDestructor.Raise();
        }
    }

    void checkColor()
    {
        if (isRed == true)
        {
            ennemyDetectionLight.color = red;
        }

        if (isBlue == true)
        {
            ennemyDetectionLight.color = blue;
        }
    }
}