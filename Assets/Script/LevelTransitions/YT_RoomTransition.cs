using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YT_RoomTransition : MonoBehaviour
{
    public int ennemisLeft = 0;
    bool killedAllEnnemis = false;
    public GameObject door;
    public LayerMask ennemisLayer;
    Vector2 centerdetection;
    public Transform centerRoom;
    public BoxCollider2D ennemisDectetion;

    // Start is called before the first frame update
    void Start()
    {
        ennemisDectetion = GetComponent<BoxCollider2D>();
        centerRoom = GameObject.Find("CenterRoom").GetComponentInParent<Transform>();
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
        door.SetActive(false);
    }
}
