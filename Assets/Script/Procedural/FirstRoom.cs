using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoom : MonoBehaviour
{

    public RoomTemplate roomTemplate;

    private int openingDirection;
    public RoomTemplate templates;
    private int rand;
    private bool spawned = false;


    void Start()
    {
        openingDirection = Random.Range(1, 4);
        templates = GameObject.Find("RoomTemplate").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
        
    }

    void Spawn()
    {
        if (spawned == false && roomTemplate.stopGeneration == false)
        {
            if (openingDirection == 1)
            {
                if (roomTemplate.roomCounter == roomTemplate.roomsUntilBoss)
                {
                    Instantiate(templates.bossRooms, transform.position, templates.bossRooms.transform.rotation);
                    roomTemplate.stopGeneration = true;
                }

                else if (roomTemplate.roomCounter == roomTemplate.roomsUntilMarket)
                {
                    Instantiate(templates.marketRooms, transform.position, templates.marketRooms.transform.rotation);
                    roomTemplate.roomCounter++;
                }

                else
                {
                    rand = Random.Range(0, templates.bottomRooms.Length);

                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                    roomTemplate.roomCounter++;
                }

            }

            else if (openingDirection == 2)
            {
                if (roomTemplate.roomCounter == roomTemplate.roomsUntilBoss)
                {
                    Instantiate(templates.bossRooms, transform.position, templates.bossRooms.transform.rotation);
                    roomTemplate.stopGeneration = true;
                }

                else if (roomTemplate.roomCounter == roomTemplate.roomsUntilMarket)
                {
                    Instantiate(templates.marketRooms, transform.position, templates.marketRooms.transform.rotation);
                    roomTemplate.roomCounter++;
                }
                else
                {
                    rand = Random.Range(0, templates.topRooms.Length);

                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    roomTemplate.roomCounter++;
                }

            }

            else if (openingDirection == 3)
            {
                if (roomTemplate.roomCounter == roomTemplate.roomsUntilBoss)
                {
                    Instantiate(templates.bossRooms, transform.position, templates.bossRooms.transform.rotation);
                    roomTemplate.stopGeneration = true;
                }

                else if (roomTemplate.roomCounter == roomTemplate.roomsUntilMarket)
                {
                    Instantiate(templates.marketRooms, transform.position, templates.marketRooms.transform.rotation);
                    roomTemplate.roomCounter++;
                }
                else
                {
                    rand = Random.Range(0, templates.leftRooms.Length);

                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                }

            }

            else if (openingDirection == 4)
            {
                if (roomTemplate.roomCounter == roomTemplate.roomsUntilBoss)
                {
                    Instantiate(templates.bossRooms, transform.position, templates.bossRooms.transform.rotation);
                    roomTemplate.stopGeneration = true;
                }

                else if (roomTemplate.roomCounter == roomTemplate.roomsUntilMarket)
                {
                    Instantiate(templates.marketRooms, transform.position, templates.marketRooms.transform.rotation);
                    roomTemplate.roomCounter++;
                }
                else
                {
                    rand = Random.Range(0, templates.leftRooms.Length);

                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);

                }

            }
            spawned = true;
        }
    }

 
}
