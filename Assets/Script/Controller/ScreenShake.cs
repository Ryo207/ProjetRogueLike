using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class ScreenShake : MonoBehaviour
{
    [BoxGroup]
    [Range(0, 10)]
    public float shakeTimeRemaining;

    [BoxGroup]
    [Range(0, 10)]
    public float shakePower;

    [BoxGroup]
    [Range(0, 10)]
    public float shakeFadeTime;

    [BoxGroup]
    [Range(0, 10)]
    public float shakeRotation;

    [BoxGroup]
    [Range(0, 10)]
    public float rotationMultiplier = 15f;

    [BoxGroup]
    [Range(0, 10)]
    private float MinimumShake = 0.1f;

    [BoxGroup]
    [Range(0, 10)]
    private float MaximumShake = 1f;

    [BoxGroup]
    [Range(0, 10)]
    private float MinimumRotation = 1f;

    [BoxGroup]
    [Range(0, 10)]
    private float MaximumRotation = 1f;

   [BoxGroup]
   public Transform mainCamera;


    void Start()
    {
      
    }

    void Update()
    {
      

        if (Input.GetKeyDown(KeyCode.K))
        {
            StartShake(shakeTimeRemaining, shakePower);

        }

    }
    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining = Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            mainCamera.position += new Vector3(xAmount, yAmount, 0f);
            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);

        }

        mainCamera.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(MinimumRotation, MaximumRotation));
    }
    void StartShake(float lenght, float power)
    {
        shakeTimeRemaining = lenght;
        shakePower = power;

        shakeFadeTime = power / lenght;

        shakeRotation = power * rotationMultiplier;

    }

}