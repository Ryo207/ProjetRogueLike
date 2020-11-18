using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject[] Room;

    void Start()
    {
        int rand = Random.Range(0, Room.Length);
        Instantiate(Room[rand], transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }
}