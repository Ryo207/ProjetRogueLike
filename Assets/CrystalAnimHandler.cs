using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalAnimHandler : MonoBehaviour
{
    public Animator EnnemiAnnimator;
    public GameObject centerEnnemy;
    public EnnemyHealth health;

    // Start is called before the first frame update
    void Start()
    {
        EnnemiAnnimator = GetComponent<Animator>();
        health = GetComponent<EnnemyHealth>();
    }

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
