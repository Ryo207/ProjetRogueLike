using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YT_RoomTransition : MonoBehaviour
{
    public int ennemisLeft = 0;
    bool killedAllEnnemis = false;
    public YTH_DoorAnimHandler doorsAnimator;
    int roomNumber;
    public GameObject door;
    public LayerMask ennemisLayer;
    Vector2 centerdetection;
    public Transform centerRoom;
    public BoxCollider2D ennemisDectetion;

    // Start is called before the first frame update
    void Start()
    {
        // Relier le système de numéro de salle à la génération procédurale
        roomNumber = 1;
        ennemisDectetion = GetComponent<BoxCollider2D>();
        centerRoom = transform.parent.GetComponentInParent<Transform>();
        doorsAnimator = GetComponentInParent<YTH_DoorAnimHandler>();
        Detection();
    }

    // Update is called once per frame
    void Update()
    {
        Detection();

        if (ennemisLeft == 0)
        {
            OpenDoor();
        }
        
    }

    void Detection()
    {
        Collider2D[] ennemisDetectionZone = Physics2D.OverlapBoxAll(centerRoom.position, ennemisDectetion.size, centerRoom.rotation.x, ennemisLayer);

        ennemisLeft = ennemisDetectionZone.Length;
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
