using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject[] Room;
    public Transform[] startingPosition;

    private int direction;
    public float moveAmount;

    public float timeBtwRoom;
    public float startTimeBtwRoom;
    void Start()
    {
        int rand = Random.Range(0, startingPosition.Length);
        transform.position = startingPosition[rand].position;
        Instantiate(Room[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);


    }

    private void Move()
    {
        if(direction == 1 || direction == 2)
        {
            Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
            transform.position = newPos;

        }
        else if (direction == 3 || direction == 4)
        {
            Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
            transform.position = newPos;


        }
        else if (direction == 5)
        {
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
            transform.position = newPos;
        }

        Instantiate(Room[0], transform.position, Quaternion.identity);
        direction = Random.Range(1, 5);
    }

        private void Update()
    {
        if (timeBtwRoom <= 0)
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