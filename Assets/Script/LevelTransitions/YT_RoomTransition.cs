using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YT_RoomTransition : MonoBehaviour
{
    public int ennemisLeft = 0;
    public YTH_DoorAnimHandler doorsAnimator;
    public GameObject door;
    public LayerMask ennemisLayer;
    public LayerMask playerLayer;
    public bool allEnnemiesDead;
    public bool pIsInside;
    public Transform centerRoom;
    public BoxCollider2D ennemisDectetion;
    Collider2D[] playerArray;
    public 

    // Start is called before the first frame update
    void Start()
    {
        ennemisDectetion = GetComponent<BoxCollider2D>();
        centerRoom = transform.parent.GetComponentInParent<Transform>();
        doorsAnimator = GetComponentInParent<YTH_DoorAnimHandler>();
        Detection();
        allEnnemiesDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        Detection();

        if (ennemisLeft == 0)
        {
            OpenDoor();
            allEnnemiesDead = true;
        }

        isInside();
        
    }

    void Detection()
    {
        Collider2D[] ennemisDetectionZone = Physics2D.OverlapBoxAll(centerRoom.position, ennemisDectetion.size, centerRoom.rotation.x, ennemisLayer);
        Collider2D[] playerDetectionZone = Physics2D.OverlapBoxAll(centerRoom.position, ennemisDectetion.size, centerRoom.rotation.x, playerLayer);

        playerArray = playerDetectionZone;
        ennemisLeft = ennemisDetectionZone.Length;
    }

    private void isInside()
    {
        if (playerArray == null || playerArray.Length == 0)
        {
            pIsInside = false;
        }
        for (int i = 0; i < playerArray.Length; i++)
        {
            if (playerArray[i] != null)
            {
                pIsInside = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(centerRoom.position, ennemisDectetion.size);
    }

    void OpenDoor()
    {

    }
}
