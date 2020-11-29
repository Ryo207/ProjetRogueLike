using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject[] Room;
    public Transform[] startingPosition;
    public GameObject[] marketRoom;

    List<Vector2> posRooms = new List<Vector2>();

    private int direction;
    public float moveAmount;

    public float timeBtwRoom;
    public float startTimeBtwRoom;

    public float minX;
    public float maxX;
    public float minY;

    public bool stopGeneration = false;

    public int downCounter;
    public int roomsCounter;

    public int roomsUntilMarket;

    void Start()
    {

        int rand = Random.Range(0, startingPosition.Length);
        transform.position = startingPosition[rand].position;
        posRooms.Add(transform.position);
        Instantiate(Room[Random.Range(0, Room.Length)], transform.position, Quaternion.identity);
        roomsCounter++;


        float x = Random.Range(1, 6);
        direction = Mathf.RoundToInt(x);
    }

    private void Move()
    {
        if (direction == 1 || direction == 2)
        {
            if (transform.position.x < maxX)
            {
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;
            }
            else
            {
                direction = 5;
            }

        }
        else if (direction == 3 || direction == 4)
        {
            if (transform.position.x > minX)
            {
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;
            }
            else
            {
                direction = 5;
            }


        }
        else if (direction == 5)
        {
            if (transform.position.y > minY)
            {
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;
                downCounter++;
                Debug.Log("DownCounter" + downCounter);
            }
            else
            {
                stopGeneration = true;
            }
        }


        if (!posRooms.Contains(transform.position))
        {
            posRooms.Add(transform.position);

            if (roomsCounter == roomsUntilMarket)
            {
                Instantiate(marketRoom[Random.Range(0, marketRoom.Length)], transform.position, Quaternion.identity);


                Debug.Log("Ekipafon");
            }
            else
            {
                Instantiate(Room[Random.Range(0, Room.Length)], transform.position, Quaternion.identity);
            }

            roomsCounter++;
            Debug.Log("roomsCounter: " + roomsCounter);
            direction = Random.Range(1, 6);

        }
    }

    void Update()
    {

            if (timeBtwRoom <= 0 && stopGeneration == false)
            {
                Move();
                timeBtwRoom = startTimeBtwRoom;
            }
            else
            {
                timeBtwRoom -= Time.deltaTime;
            }

    }
}