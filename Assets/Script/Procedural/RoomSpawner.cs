using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public RoomTemplate roomTemplate;

    public int openingDirection;

    private int rand;
    private bool spawned = false;
  

    void Start()
    {
        roomTemplate = GameObject.Find("RoomTemplate").GetComponent<RoomTemplate>();
        Invoke("Spawn",0.1f ) ;
    }

    void Spawn()
    {
        if (spawned == false && roomTemplate.roomCounter > 30f)
        {

            if (openingDirection == 1)
            {
                if (roomTemplate.roomCounter == roomTemplate.roomsUntilBoss && roomTemplate.bossSpawned == false)
                {
                    Instantiate(roomTemplate.bossRooms, transform.position, roomTemplate.bossRooms.transform.rotation);
                    roomTemplate.bossSpawned = true;
                }

                else if (roomTemplate.roomCounter == roomTemplate.roomsUntilMarket && roomTemplate.marketSpawned == false)
                {
                 
                    Instantiate(roomTemplate.marketRooms, transform.position, roomTemplate.marketRooms.transform.rotation);
                    roomTemplate.marketSpawned = true;
                    roomTemplate.roomCounter++;
                }

                else
                {
                    rand = Random.Range(0, roomTemplate.bottomRooms.Length);

                    Instantiate(roomTemplate.bottomRooms[rand], transform.position, roomTemplate.bottomRooms[rand].transform.rotation);
                    roomTemplate.roomCounter++;
                }

            }

            else if (openingDirection == 2)
            {
                if (roomTemplate.roomCounter == roomTemplate.roomsUntilBoss && roomTemplate.bossSpawned == false)
                {
                    Instantiate(roomTemplate.bossRooms, transform.position, roomTemplate.bossRooms.transform.rotation);
                    roomTemplate.bossSpawned = true;
                }

                else if (roomTemplate.roomCounter == roomTemplate.roomsUntilMarket && roomTemplate.marketSpawned == false)
                {
                    Instantiate(roomTemplate.marketRooms, transform.position, roomTemplate.marketRooms.transform.rotation);
                    roomTemplate.marketSpawned = true;
                    roomTemplate.roomCounter++;
                }
                else
                {
                    rand = Random.Range(0, roomTemplate.topRooms.Length);

                    Instantiate(roomTemplate.topRooms[rand], transform.position, roomTemplate.topRooms[rand].transform.rotation);
                    roomTemplate.roomCounter++;
                }

            }

            else if (openingDirection == 3)
            {
                if (roomTemplate.roomCounter == roomTemplate.roomsUntilBoss && roomTemplate.bossSpawned == false)
                {
                    Instantiate(roomTemplate.bossRooms, transform.position, roomTemplate.bossRooms.transform.rotation);
                    roomTemplate.bossSpawned = true;
                }

                else if (roomTemplate.roomCounter == roomTemplate.roomsUntilMarket && roomTemplate.marketSpawned == false)
                {
                    Instantiate(roomTemplate.marketRooms, transform.position, roomTemplate.marketRooms.transform.rotation);
                    roomTemplate.marketSpawned = true;

                    roomTemplate.roomCounter++;
                }
                else
                {
                    rand = Random.Range(0, roomTemplate.leftRooms.Length);
                    Instantiate(roomTemplate.leftRooms[rand], transform.position, roomTemplate.leftRooms[rand].transform.rotation);
                }

            }

            else if (openingDirection == 4)
            {
                if (roomTemplate.roomCounter == roomTemplate.roomsUntilBoss && roomTemplate.bossSpawned == false)
                {
                    Instantiate(roomTemplate.bossRooms, transform.position, roomTemplate.bossRooms.transform.rotation);
                    roomTemplate.bossSpawned = true;
                }

                else if (roomTemplate.roomCounter == roomTemplate.roomsUntilMarket && roomTemplate.marketSpawned == false)
                {
                    Instantiate(roomTemplate.marketRooms, transform.position, roomTemplate.marketRooms.transform.rotation);
                    roomTemplate.marketSpawned = true;
                    roomTemplate.roomCounter++;
                }
                else
                {
                    rand = Random.Range(0, roomTemplate.leftRooms.Length);
                    Instantiate(roomTemplate.leftRooms[rand], transform.position, roomTemplate.leftRooms[rand].transform.rotation);

                }

            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            if (collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(roomTemplate.marketRooms, transform.position, Quaternion.identity);
                Destroy(gameObject);
                

            }
            spawned = true;
        }
    }
}
