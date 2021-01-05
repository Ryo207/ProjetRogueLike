using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public List<GameObject> currentRooms;

    public GameObject marketRooms;
    public GameObject bossRooms;

    public int roomCounter;
    public bool stopGeneration = false;

    public int roomsUntilMarket;
    public int roomsUntilMarketMin;
    public int roomsUntilMarketMax;

    public int roomsUntilBoss;
    public int roomsUntilBossMin;
    public int roomsUntilBossMax;

    public bool marketSpawned = false;
    public bool bossSpawned = false;


    private void Start()
    {
        roomsUntilBoss = Random.Range(roomsUntilBossMin, roomsUntilBossMax);
        roomsUntilMarket = Random.Range(roomsUntilMarketMin, roomsUntilMarketMax);
    }

}
