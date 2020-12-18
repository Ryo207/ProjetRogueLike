using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YTH_DoorAnimHandler : MonoBehaviour
{
    public Animator[] doors;
    int numberofDoors;
    YT_RoomTransition ennemisDectection;
    // Start is called before the first frame update
    void Start()
    {
        numberofDoors = doors.Length;
        ennemisDectection = GetComponentInChildren<YT_RoomTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ennemisDectection.ennemisLeft == 0)
        {
            for(int i = 0; i < numberofDoors; i++)
            {
                openDoor(doors[i]);
            }
        }
    }

    void openDoor(Animator doors)
    {
        doors.SetBool("IsOpen", true);
    }
}
