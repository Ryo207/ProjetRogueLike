using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeverTrigger : MonoBehaviour
{
    //public UnityEngine.Experimental.Rendering.Universal.Light2D GlobalLight;

    public bool lightMilestone = false;
    public Animator Light;

    public void Start()
    {
        Light.SetBool("IsRed", false);
        Light.SetBool("IsBlue",false);
    }
    public void RedLight()
    {
        lightMilestone = false;
        Light.SetBool("IsRed", true);
        Light.SetBool("IsBlue", false);
    }

    public void BlueLight()
    {
        lightMilestone = true;
        Light.SetBool("IsBlue", true);
        Light.SetBool("IsRed", false);
    }
}