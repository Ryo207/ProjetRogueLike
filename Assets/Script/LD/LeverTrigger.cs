using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeverTrigger : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D GlobalLight;

    public bool lightMilestone = false;


    public void RedLight()
    {
        lightMilestone = false;
        GlobalLight.color = Color.red;
    }

    public void BlueLight()
    {
        lightMilestone = true;
        GlobalLight.color = Color.blue;
    }
}