using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : MonoBehaviour
{
    ItemDetection itemD;

    public int necessaryCoins;

    private void Start()
    {
        itemD = GameObject.Find("DetectionZone").GetComponent<ItemDetection>();
    }

    void getUpgrade()
    {
        if (necessaryCoins < itemD.currentCoins)
        {

        }
    }


}
