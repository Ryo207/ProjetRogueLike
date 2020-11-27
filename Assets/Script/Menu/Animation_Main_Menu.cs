using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Main_Menu : MonoBehaviour
{
    public Animator SplashScreen1;
    public Animator SplashScreen2;
    public Animator SplashScreen3;
    public Animator SplashScreen4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SplashScreen1.SetBool("Gone", true);
            SplashScreen2.SetBool("Gone", true);
            SplashScreen3.SetBool("Gone", true);
            SplashScreen4.SetBool("Gone", true);
        }
    }
}
