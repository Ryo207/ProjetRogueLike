using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    private CinemachineBasicMultiChannelPerlin virtualCamNoise;
    PlayerController controller;

    public float shakeTimeRemaining;
    public float shakePower;
    public float shakeFadeTime;

    void Start()
    {
        virtualCamNoise = virtualCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartShake(shakeTimeRemaining, shakeFadeTime);
            print("Wesh");
        }
    }

    void LateUpdate()
    {
        doShake();
    }

    void doShake()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
            virtualCamNoise.m_AmplitudeGain = shakePower;
        }
        else
        {
            shakeTimeRemaining = 0f;
            virtualCamNoise.m_AmplitudeGain = 0f;
        }
    }

    private void StartShake(float lenght, float power)
    {

        shakeTimeRemaining = lenght;
        shakePower = power;

        shakeFadeTime = power / lenght;
    }
}


