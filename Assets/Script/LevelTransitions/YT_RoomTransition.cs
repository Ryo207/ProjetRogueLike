using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YT_RoomTransition : MonoBehaviour
{
    int ennemisLeft = 0;
    bool killedAllEnnemis = false;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        CheckNumberEnnemies();
    }

    // Update is called once per frame
    void Update()
    {
        CheckNumberEnnemies();

        if (ennemisLeft == 0)
        {
            OpenDoor();
        }

        if (killedAllEnnemis == true)
        {

        }
        
    }

    void CheckNumberEnnemies()
    {
        GameObject[] ennemis = GameObject.FindGameObjectsWithTag("Ennemy");
        ennemisLeft = ennemis.Length;
    }

    void OpenDoor()
    {
        killedAllEnnemis = true;
        door.SetActive(false);
    }
}
