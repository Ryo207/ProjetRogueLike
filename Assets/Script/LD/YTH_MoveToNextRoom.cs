using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YTH_MoveToNextRoom : MonoBehaviour
{
    public Transform perso;
    public Transform tpPoint;
    // Start is called before the first frame update
    void Start()
    {
        perso = GameObject.Find("Perso").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            perso.position = tpPoint.position;
        }
        
    }
}
