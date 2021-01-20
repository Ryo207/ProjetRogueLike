using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public static PlayerController instance;
    void Awake() => instance = this;

    //Variable Mouvement Perso
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;

    [Header("VirtualAxis"), SerializeField]
    private float xAxisSensitivity;
    [SerializeField]
    private float yAxisSensitivity;
    private float virtualXRawAxis, virtualYRawAxis, virtualXAxis, virtualYAxis;
    [SerializeField]
    private int xAccelerationFrame, xDecelerationFrame, yAccelerationFrame, yDecelerationFrame;

    public Camera cam;
    public bool closeToLever;

    public LeverTrigger levertrigger;

    [SerializeField]
    private GameObject parryCollider;

    //variable MGSBox
    public GameObject player;
    [SerializeField]
    ItemDetection activeItem;
    [SerializeField]
    ItemCharge itemCharge;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        activeItem = GetComponentInChildren<ItemDetection>();
        itemCharge = GetComponent<ItemCharge>();
    }

    void FixedUpdate()
    {
        doPlayerSpeed();
    }

    void Update()
    {
        Movement();
        manageVirtualRawAxis();
        manageVirtualAxis();
        MGSBox();
    }

    private void manageVirtualRawAxis()
    {
        if (Input.GetAxisRaw("Horizontal") >= xAxisSensitivity)
        {
            virtualXRawAxis = 1f;
        }
        else if (Input.GetAxisRaw("Horizontal") <= -xAxisSensitivity)
        {
            virtualXRawAxis = -1f;
        }
        else
        {
            virtualXRawAxis = 0f;
        }

        if (Input.GetAxisRaw("Vertical") >= yAxisSensitivity)
        {
            virtualYRawAxis = 1f;
        }
        else if (Input.GetAxisRaw("Vertical") <= -yAxisSensitivity)
        {
            virtualYRawAxis = -1f;
        }
        else
        {
            virtualYRawAxis = 0f;
        }
    }

    private void manageVirtualAxis()
    {
        if (virtualXRawAxis == 1f && virtualXAxis < 1f)
        {
            virtualXAxis += 1f / (float)xAccelerationFrame;
        }
        else if (virtualXRawAxis == -1f && virtualXAxis > -1f)
        {
            virtualXAxis -= 1f / (float)xAccelerationFrame;
        }
        else if (virtualXRawAxis == 0f)
        {
            if (virtualXAxis > 0f)
            {
                virtualXAxis -= 1f / (float)xDecelerationFrame;
            }
            if (virtualXAxis < 0f)
            {
                virtualXAxis += 1f / (float)xDecelerationFrame;
            }
        }

        if (virtualXAxis > 1f)
        {
            virtualXAxis = 1f;
        }
        else if (virtualXAxis < -1f)
        {
            virtualXAxis = -1f;
        }
        else if (virtualXRawAxis == 0f && virtualXAxis > -(1f / (float)xDecelerationFrame) && virtualXAxis < 1f / (float)xDecelerationFrame)
        {
            virtualXAxis = 0f;
        }


        if (virtualYRawAxis == 1f && virtualYAxis < 1f)
        {
            virtualYAxis += 1f / (float)yAccelerationFrame;
        }
        else if (virtualYRawAxis == -1f && virtualYAxis > -1f)
        {
            virtualYAxis -= 1f / (float)yAccelerationFrame;
        }
        else if (virtualYRawAxis == 0f)
        {
            if (virtualYAxis > 0f)
            {
                virtualYAxis -= 1f / (float)yDecelerationFrame;
            }
            if (virtualYAxis < 0f)
            {
                virtualYAxis += 1f / (float)yDecelerationFrame;
            }
        }

        if (virtualYAxis > 1f)
        {
            virtualYAxis = 1f;
        }
        else if (virtualYAxis < -1f)
        {
            virtualYAxis = -1f;
        }
        else if (virtualYRawAxis == 0f && virtualYRawAxis > -(1f / (float)yDecelerationFrame) && virtualYAxis < 1f / (float)yDecelerationFrame)
        {
            virtualYAxis = 0f;
        }
    }

    private void doPlayerSpeed()
    {
        Vector2 axisVector = new Vector2(virtualXAxis, virtualYAxis);

        if (axisVector.magnitude > 1f)
        {
            axisVector.Normalize();
        }

        rb.velocity = (axisVector * moveSpeed);
    }

    void Movement()
    {
        movement.x = virtualXRawAxis;
        movement.y = virtualYRawAxis;
    }

    void MGSBox()
    {
        if (Input.GetKeyDown(KeyCode.Space) && activeItem.MGSBox == true &&  itemCharge.useActiveItem == true)
        {
            itemCharge.chargesisUsed();
            StartCoroutine(nameof(NoDetectionTime));
        }
    }

    IEnumerator NoDetectionTime()
    {
        player.tag = "NoDetection";
        yield return new WaitForSeconds(10); //Valeur temporaire à modifier 
        player.tag = "Player";
    }
}
