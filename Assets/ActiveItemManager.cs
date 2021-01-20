using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItemManager : MonoBehaviour
{
    public YT_RoomTransition[] playerCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCheck = GameObject.Find("EnnemisDetection").GetComponents<YT_RoomTransition>();
    }


}
