using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnnemyViewCrystalSpawner : MonoBehaviour
{
    [SerializeField]
    public bool isRed;
    public bool isBlue;

    [SerializeField]
    PathFinding pathFinding;


    public Light2D ennemyDetectionLight;
    public Color blue;
    public Color red;

    [SerializeField]
    FightingPhaseManager fpManager;

    [SerializeField]
    GameEvent TilemapDestructor;


    public void Start()
    {
        ennemyDetectionLight = GetComponent<Light2D>();
        fpManager = FightingPhaseManager.instance;
    }

    private void FixedUpdate()
    {
        checkColor();
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
