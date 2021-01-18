using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    float lockPos = 0;


    void Start()
    {
        
    }


    void Update()
    {
       
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
        
    }
}
