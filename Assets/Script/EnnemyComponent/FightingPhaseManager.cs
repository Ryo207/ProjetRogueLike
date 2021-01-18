using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingPhaseManager : MonoBehaviour
{

    public static FightingPhaseManager instance;
    void Awake() => instance = this;

    [SerializeField]
    PathFinding[] pathfinding;
    [SerializeField]
    EnnemyView[] ennemyColor;
    [SerializeField]
    LeverTrigger roomColor;
    [SerializeField]
    ItemDetection activeItem;
    [SerializeField]
    YT_RoomTransition detectPlayer;
    [SerializeField]
    ItemCharge itemCharge;
    public bool hiveMind;

    private void Start()
    {
        pathfinding = GetComponentsInChildren<PathFinding>();
        ennemyColor = GetComponentsInChildren<EnnemyView>();
        roomColor = GetComponentInParent<LeverTrigger>();
        itemCharge = GameObject.Find("Perso").GetComponent<ItemCharge>();
        activeItem = GameObject.Find("DetectionZone").GetComponent<ItemDetection>();
        detectPlayer = GameObject.Find("EnnemisDetection").GetComponent<YT_RoomTransition>();
        hiveMind = false;
    }

    private void Update()
    {
        DetectHiveMind();

        ColorBomb();
    }

    void DetectHiveMind()
    {
        if (hiveMind == true)
        {
            for (int i = 0; i < pathfinding.Length; i++)
            {
                pathfinding[i].FightingPhase = true;
            }
        }
    }
    void ColorBomb()
    {

        if (activeItem.ColorBomb == true && itemCharge.useActiveItem == true && Input.GetKeyDown(KeyCode.Space))
        {
            itemCharge.chargesisUsed();
            for (int i = 0; i < ennemyColor.Length; i++)
            {
                if (ennemyColor[i].isRed == true && roomColor.lights[0].color == roomColor.blue)
                {
                    ennemyColor[i].isBlue = true;
                    ennemyColor[i].isRed = false;
                }

                if (ennemyColor[i].isBlue == true && roomColor.lights[0].color == roomColor.red)
                {
                    ennemyColor[i].isRed = true;
                    ennemyColor[i].isBlue = false;
                }

            }

        }
    }
}
