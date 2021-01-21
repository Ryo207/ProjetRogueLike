using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Animation_Main_Menu : MonoBehaviour
{
    public Animator SplashScreen;
    bool canPlay = false;
    public VideoPlayer intro;
    
    void Start()
    {
        SplashScreen = GetComponent<Animator>();
        FindObjectOfType<AudioManager>().Play("MainTheme");
        StartCoroutine(nameof(stopvideo));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && canPlay == true)
        {
            SplashScreen.SetBool("Gone", true);
            intro.Stop();
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SplashScreen.SetBool("Stop", true);
            canPlay = true;
        }
    }

    IEnumerator stopvideo()
    {
        yield return new WaitForSeconds(65);
        SplashScreen.SetBool("Stop", true);
        intro.Stop();
        canPlay = true;
    }
}
