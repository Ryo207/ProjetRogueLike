using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyViewCrystalSpawner : MonoBehaviour
{
    [SerializeField]
    PathFinding pathFinding;

    [SerializeField]
    FightingPhaseManager fpManager;

    [SerializeField]
    GameEvent TilemapDestructor;

    public float speed = 5f;


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
