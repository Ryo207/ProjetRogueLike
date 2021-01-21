using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class LeverTrigger : MonoBehaviour
{
    //public UnityEngine.Experimental.Rendering.Universal.Light2D GlobalLight;

    public bool isRed;
    public bool isBlue;
    public float lightIntensity;
    public YT_RoomTransition roomTransition;
    public Light2D[] lights;
    public Light2D ambiantLight;
    public Color red;
    public Color blue;
    bool closeToLever;
    Animator leverAnim;

    public bool stopLever; //Relier directement le script au pathfinding, ce sera plus simple dans l'autre sens.

    [SerializeField]
    FightingPhaseManager ennemiDetection;

    
    public void Start()
    {
        leverAnim = GetComponent<Animator>();
        ambiantLight = GameObject.Find("AmbiantLight").GetComponent<Light2D>();
        lightIntensity = 0.5f;

        if (isRed == true)
        {
            RedLight();
        }
        else if (isBlue == true)
        {
            BlueLight();
        }
    }
    public void RedLight()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].color = red;
        }
    }

    public void BlueLight()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].color = blue;
        }
    }

    void ActivateLever()
    {
        if (Input.GetKeyDown(KeyCode.T) && closeToLever == true)
        {
            if (isRed == true)
            {
                FindObjectOfType<AudioManager>().Play("Levier");
                BlueLight();
                isRed = false;
                isBlue = true;
            }
            else if (isBlue == true)
            {
                FindObjectOfType<AudioManager>().Play("Levier");
                RedLight();
                isBlue = false;
                isRed = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            closeToLever = true;
            Debug.Log("Close To Lever");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            closeToLever = false;
        }
    }

    private void Update()
    {
        ActivateLever();
        ambiantLight.intensity = lightIntensity;
        leverAnim.SetBool("IsRed", isRed);
        leverAnim.SetBool("IsBlue", isBlue);

        if (ennemiDetection.hiveMind == true )
        {
            if (lightIntensity <= 0.8f && roomTransition.ennemisLeft > 0)
            {
                lightIntensity += Time.deltaTime;
            }

            else if (lightIntensity >= 0.5f && roomTransition.ennemisLeft == 0)
            {
                lightIntensity -= Time.deltaTime;
            }
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}