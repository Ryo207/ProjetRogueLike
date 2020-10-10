using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeverTrigger : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D GlobalLight;
    void Start()
    {
        GlobalLight = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();

    }

    public void RedLight()
    {
        GlobalLight.color = Color.red;
    }

    public void BlueLight()
    {
        GlobalLight.color = Color.blue;
    }
}