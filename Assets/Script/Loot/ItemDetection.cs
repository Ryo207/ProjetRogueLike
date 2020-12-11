using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetection : MonoBehaviour
{
    bool isUsed;

    ItemTypeEnum itemType;

    ConsumablesTypesEnum consumableType;

    Image imgCacWepon;

    Image imgDistWeapon;

    Image activeObject;

    public Image[] passiveObject;

    int imgIndex;

    PlayerController controller;

    CircleCollider2D itemCollider;

    PlayerHealth health;

    PlayerShoot attackDist;

    PlayerAttack attackCaC;

    GameObject detectionZone;

    GameObject player;


    [SerializeField]
    string ItemTag;


    private void Awake()
    {
        instantiatePlayerComponents();
    }

    private void Start()
    {
        itemCollider = GetComponent<CircleCollider2D>();
        imgCacWepon = GameObject.Find("CacWeapon").GetComponent<Image>();
        imgDistWeapon = GameObject.Find("DistWeapon").GetComponent<Image>();
        activeObject = GameObject.Find("ActiveObject").GetComponent<Image>();
        imgIndex = 0;
    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(ItemTag))
        {
            grabObjt(col.gameObject.GetComponent<Item>()._Scriptable);

            if (isUsed == true)
            {
                Destroy(col.gameObject);
                isUsed = false;
            }

        }

        else{}
    }

    void grabObjt(ItemsSO _Scriptable)
    {
        itemType = _Scriptable.itemType;
        consumableType = _Scriptable.consumableType;

        if (itemType == ItemTypeEnum.CacWeapon)
        {
            attackCaC.DamageCaC = _Scriptable.damageCac;
            attackCaC.impactTime = _Scriptable.ImpactTime;
            attackCaC.attackIntervale = _Scriptable.cooldownCac;
            imgCacWepon.sprite = _Scriptable.Artwork;
            
            isUsed = true;
        }

        if (itemType == ItemTypeEnum.DistanceWeapon)
        {
            attackDist.DamageDist = _Scriptable.damageDistance;
            attackDist.bulletPrefab = _Scriptable.bulletPrefab;
            attackDist.shootIntervale = _Scriptable.weaponCooldownDistance;
            isUsed = true;
        }

        else if (itemType == ItemTypeEnum.Consumables)
        {
            if (consumableType == ConsumablesTypesEnum.Heal && health.PlayerLife != health.maxPlayerLife && _Scriptable.IsPermanent == false)
            {
                health.PlayerLife += _Scriptable.healingPoints;
                isUsed = true;
            }

            else if (consumableType == ConsumablesTypesEnum.Heal && _Scriptable.IsPermanent == true)
            {
                health.maxPlayerLife += _Scriptable.healingPoints;
                health.PlayerLife += _Scriptable.healingPoints;
                passiveObject[imgIndex].sprite = _Scriptable.Artwork;
                imgIndex++;
                isUsed = true;
            }

            else if (consumableType == ConsumablesTypesEnum.Speed && _Scriptable.IsPermanent == false)
            {
                controller.moveSpeed *= _Scriptable.speedMultiplication;
                isUsed = true;
            }

            else if (consumableType == ConsumablesTypesEnum.Speed && _Scriptable.IsPermanent == true)
            {
                controller.moveSpeed *= _Scriptable.speedMultiplication;
                passiveObject[imgIndex].sprite = _Scriptable.Artwork;
                imgIndex++;
                isUsed = true;
            }

            else if (consumableType == ConsumablesTypesEnum.Strengh && _Scriptable.IsPermanent == false)
            {
                attackCaC.DamageCaC *= _Scriptable.damageMultiplication;
                attackDist.DamageDist *= _Scriptable.damageMultiplication;
                isUsed = true;
            }

            else if (consumableType == ConsumablesTypesEnum.Strengh && _Scriptable.IsPermanent == true)
            {
                attackCaC.DamageCaC *= _Scriptable.damageMultiplication;
                attackDist.DamageDist *= _Scriptable.damageMultiplication;
                passiveObject[imgIndex].sprite = _Scriptable.Artwork;
                imgIndex++;
                isUsed = true;

            }
        }
    }

    void instantiatePlayerComponents()
    {
        player = GameObject.Find("Perso");
        attackDist = player.GetComponent<PlayerShoot>();
        attackCaC = player.GetComponent<PlayerAttack>();
        health = player.GetComponent<PlayerHealth>();

    }
}
