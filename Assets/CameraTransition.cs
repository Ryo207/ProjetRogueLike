using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public float xCoordinates;
    public float yCoordinates;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Camera.main.transform.position = transform.position + new Vector3(xCoordinates, yCoordinates, -10);
        }
    }
}
