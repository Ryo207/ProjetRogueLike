using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YT_LevelGeneration : MonoBehaviour
{
    Vector2 worldSize = new Vector2(5, 5);
    Room[,] rooms;
    List<Vector2> roomTaken = new List<Vector2>();

    int levelSizeX, levelSizeY, numberOfRooms = 20;
    public GameObject roomMapTemplate;
    public Transform mapRoot;

    void Start()
    {
        if (numberOfRooms >= (worldSize.x * 2) * (worldSize.y * 2))
        {
            numberOfRooms = Mathf.RoundToInt((worldSize.x * 2) * (worldSize.y * 2));
        }

        levelSizeX = Mathf.RoundToInt(worldSize.x);
        levelSizeY = Mathf.RoundToInt(worldSize.y);
    }

    void CreateRooms()
    {
        rooms = new Room[levelSizeX * 2, levelSizeY * 2];
        rooms[levelSizeX, levelSizeY] = new Room(Vector2.zero, 1);
        roomTaken.Insert(0, Vector2.zero);
        Vector2 checkPos = Vector2.zero;

        float randomCompare = 0.2f, randomCompareStart = 0.2f, randomCompareEnd = 0.01f;

        for (int i = 0; i < numberOfRooms -1; i++)
        {
            float randomPerc = ((float) i) / (((float)numberOfRooms - 1));
            randomCompare = Mathf.Lerp(randomCompareStart, randomCompareEnd, randomPerc);
            checkPos = NewPosition();
        }

    }

    Vector2 NewPosition()
    {
        int x = 0, y = 0;
        Vector2 checkingPos = Vector2.zero;
        do
        {
            int index = Mathf.RoundToInt(Random.value * (roomTaken.Count - 1));
            x = (int)roomTaken[index].x;
            y = (int)roomTaken[index].y;
            bool UpDown = (Random.value < 0.5f);
            bool positive = (Random.value < 0.5f);
            if (UpDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y);
        }
        while (roomTaken.Contains(checkingPos) || x >= levelSizeX || x < -levelSizeX || y >= levelSizeY || y < -levelSizeY);
        return checkingPos;
    }
}
