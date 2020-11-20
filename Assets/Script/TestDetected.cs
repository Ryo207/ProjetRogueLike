using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDetected : MonoBehaviour
{
    ItemsSO detection;

    bool detected = false;

    public CircleCollider2D itemCollider;

    [SerializeField]
    string tagName;

    
    void Update()
    {
        detection.isDetected = detected;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(tagName))
        {
            detected = true;
        }

        else
        {
            detected = false;
        }
    }
}
