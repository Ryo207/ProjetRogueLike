using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YT_EnnemiAnimHandler : MonoBehaviour
{
    public Animator EnnemiAnnimator;
    public GameObject centerEnnemy;

    // Update is called once per frame
    void Update()
    {
        TurnEnnemi();
    }

    void TurnEnnemi()
    {
        EnnemiAnnimator.SetFloat("Angle", centerEnnemy.transform.rotation.eulerAngles.z);
    }
}
