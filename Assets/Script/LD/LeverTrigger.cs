using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class LeverTrigger : MonoBehaviour
{
    //public UnityEngine.Experimental.Rendering.Universal.Light2D GlobalLight;

    public bool lightMilestone = false;
    public float lightIntensity;
    public YT_RoomTransition roomTransition;
    public Animator Lumiere;
    public Light2D[] lights;
    public Light2D ambiantLight;
    public Color red;
    public Color blue;
    float chooseColor;

    public bool stopLever; //Relier directement le script au pathfinding, ce sera plus simple dans l'autre sens.

    [SerializeField]
    FightingPhaseManager ennemiDetection;

    
    public void Start()
    {
        Lumiere = GameObject.Find("LeverColor").GetComponent<Animator>();
        chooseColor = Random.Range(1, 3);
        lightIntensity = 0.5f;

        if (chooseColor == 1)
        {
            RedLight();
        }
        else if (chooseColor == 2)
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

    private void Update()
    {
        ambiantLight.intensity = lightIntensity;

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