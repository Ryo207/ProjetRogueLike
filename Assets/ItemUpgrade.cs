using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemUpgrade : MonoBehaviour
{
    TMP_Text coinsTXT;
    ItemDetection itemD;
    Animator enclumeAnim;
    public GameObject swordLvL2;
    public GameObject distLvL2;
    public GameObject swordLvL3;
    public GameObject distLvL3;
    bool isInside;
    public bool level2 = false;
    public bool level3 = false;
    bool canUpgrade = false;

    public int necessaryCoinsPhase1;
    public int necessaryCoinsPhase2;

    private void Start()
    {
        itemD = GameObject.Find("DetectionZone").GetComponent<ItemDetection>();
        enclumeAnim = GetComponent<Animator>();
        coinsTXT = GetComponentInChildren<TMP_Text>();

        coinsTXT.text = necessaryCoinsPhase1.ToString();

    }

    private void Update()
    {
        enclumeAnim.SetBool("Enter", isInside);
        UpgradeToLevel2();
        UpgradeToLevel3();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isInside = false;
        }
    }

    void UpgradeToLevel2()
    {
        if (necessaryCoinsPhase1 <= itemD.currentCoins && level2 == false && isInside == true && canUpgrade == false && Input.GetKeyDown(KeyCode.I))
        {
            level2 = true;
            Instantiate(swordLvL2, gameObject.transform.position, Quaternion.identity);
            Instantiate(distLvL2, gameObject.transform.position, Quaternion.identity);
            Debug.Log("Level2 Taken");
            itemD.currentCoins -= necessaryCoinsPhase1;
            isInside = false;
            coinsTXT.text = necessaryCoinsPhase2.ToString();
            canUpgrade = true;
        }
    }

    void UpgradeToLevel3()
    {
        if (necessaryCoinsPhase2 <= itemD.currentCoins && level3 == false && isInside == true && canUpgrade == true && Input.GetKeyDown(KeyCode.I))
        {
            level2 = false;
            level3 = true;
            Instantiate(swordLvL3, gameObject.transform.position, Quaternion.identity);
            Instantiate(distLvL3, gameObject.transform.position, Quaternion.identity);
            Debug.Log("Level3 Taken");
            itemD.currentCoins -= necessaryCoinsPhase2;
            isInside = false;
            enclumeAnim.SetBool("Stop", true);
        }
    }


}
