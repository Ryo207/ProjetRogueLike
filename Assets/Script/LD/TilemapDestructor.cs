using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class TilemapDestructor : MonoBehaviour
{
    [SerializeField]
    PathFinding pathFinding;

    [SerializeField]
    NavMeshSurface2d surface;

    void Start()
    {

    }

    void Update()
    {
        if (pathFinding.FightingPhase == true)
        {
      
                gameObject.GetComponent<TilemapCollider2D>().enabled = false;
                gameObject.GetComponent<TilemapRenderer>().enabled = false;
                // surface.UpdateNavMesh(surface.navMeshData);
                // surface.Bake();
                //  Debug.Log(surface);

        }
    }
}
            
