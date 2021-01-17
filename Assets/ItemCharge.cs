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

    bool useActiveItem;



    private void Start()
    {
        activeItem = GetComponentInChildren<ItemDetection>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            useActiveItem = true;
            chargesisUsed();
        }
    }
    public void chargesColor()
    {
        for (int i = 0; i < activeItem.numberOfCharges; i++)
        {
            chargingBarsImage[i].sprite = whiteCase;
            chargingBarsImage[i].color = green;
        }
    }

    void chargesisUsed()
    {
        if (useActiveItem == true)
        {
            for (int i = 0; i < activeItem.numberOfCharges; i++)
            {
                chargingBarsImage[i].color = white;
            }
        }
    }
}
