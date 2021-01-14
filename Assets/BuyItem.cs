using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyItem : MonoBehaviour
{
    ItemDetection coinCount;

    TMP_Text numberCoinsTXT;

    public GameObject item;

    Animator itemAnim;

    public int itemCost;

    bool isInside;

    private void Start()
    {
        coinCount = GameObject.Find("DetectionZone").GetComponent<ItemDetection>();
        itemAnim = GetComponent<Animator>();
        numberCoinsTXT = GetComponentInChildren<TMP_Text>();


        numberCoinsTXT.text = itemCost.ToString();
        isInside = false;
    }

    private void Update()
    {
        checkIfBuy();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
      if (col.CompareTag("Player"))
      {
        itemAnim.SetBool("Enter", true);

        isInside = true;
      }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            itemAnim.SetBool("Enter", false);
        }
        
    }

    void checkIfBuy()
    {
        if (itemCost <= coinCount.currentCoins && Input.GetKeyDown(KeyCode.I) && isInside == true)
        {
            Instantiate(item, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log("ObjectTaken");
        }
    }

}
