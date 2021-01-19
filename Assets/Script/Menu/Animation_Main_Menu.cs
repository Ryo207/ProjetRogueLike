using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Main_Menu : MonoBehaviour
{
    public Animator SplashScreen;
    void Start()
    {
        SplashScreen = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SplashScreen.SetBool("Gone", true);
        }
    }
}
