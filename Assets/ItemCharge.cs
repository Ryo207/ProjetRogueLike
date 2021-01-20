using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCharge : MonoBehaviour
{
    ItemDetection activeItem;
    public Image[] chargingBarsImage;

    public Color green;
    public Color white;

    public Sprite whiteCase;
    public Sprite emptyCase;

    public bool useActiveItem;

    public int itemReady;



    private void Start()
    {
        activeItem = GetComponentInChildren<ItemDetection>();
        useActiveItem = true;
    }

    private void Update()
    {
    }
    public void chargesColor()
    {
        for (int i = 0; i < activeItem.numberOfCharges; i++)
        {
            chargingBarsImage[i].sprite = whiteCase;
            chargingBarsImage[i].color = green;
            useActiveItem = true;
        }

        for (int i = activeItem.numberOfCharges; i < chargingBarsImage.Length; i++)
        {
            chargingBarsImage[i].sprite = emptyCase;
        }
    }

    public void chargesisUsed()
    {
        for (int i = 0; i < activeItem.numberOfCharges; i++)
        {
            chargingBarsImage[i].color = white;
            useActiveItem = false;
            itemReady = -1;
        }
    }

    public void chargeback()
    {
        if(itemReady <= chargingBarsImage.Length)
        {
            chargingBarsImage[itemReady].color = green;
        }
        if(itemReady == chargingBarsImage.Length)
        {
            useActiveItem = true;
            Debug.Log("CanUseItem");
        }
    }
}
