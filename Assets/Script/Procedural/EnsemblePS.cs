using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnsemblePS : MonoBehaviour
{

    public GameObject[] PrefabLD;
    private int rand;




    void Start()
    {
        rand = Random.Range(0, PrefabLD.Length);
        Instantiate(PrefabLD[rand], transform.position, PrefabLD[rand].transform.rotation);


    }

    
}
