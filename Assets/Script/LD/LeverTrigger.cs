using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeverTrigger : MonoBehaviour
{
    //public UnityEngine.Experimental.Rendering.Universal.Light2D GlobalLight;

    public bool lightMilestone = false;
    public Animator Lumiere;

    public bool stopLever; //Relier directement le script au pathfinding, ce sera plus simple dans l'autre sens.

    [SerializeField]
    PathFinding pathFinding; 

    
    public void Start()
    {
        Lumiere = GameObject.Find("LeverColor").GetComponent<Animator>();
        Lumiere.SetBool("IsRed", false);
        Lumiere.SetBool("IsBlue",false);
    }
    public void RedLight()
    {
        lightMilestone = false;
        Lumiere.SetBool("IsRed", true);
        Lumiere.SetBool("IsBlue", false);
    }

    public void BlueLight()
    {
        lightMilestone = true;
        Lumiere.SetBool("IsBlue", true);
        Lumiere.SetBool("IsRed", false);
    }

    private void Update()
    {
        if (pathFinding.FightingPhase == true )
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}