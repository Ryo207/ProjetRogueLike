using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[CreateAssetMenu(fileName = "New Item", menuName = "Items")]
public class ItemsSO : ScriptableObject
{
    [HorizontalGroup("ScriptableObjectBaseHorizontal", 335)]
    [PreviewField(100)]
    [HideLabel]
    public Sprite Artwork;

    [VerticalGroup("ScriptableObjectBaseVertical")]
    [LabelWidth(100)]
    public string Itemname;

    [VerticalGroup("ScriptableObjectBaseVertical")]
    [LabelWidth(100)]
    public int ID;

    [VerticalGroup("ScriptableObjectBaseVertical")]
    [LabelWidth(100)]
    public int Price;

    [VerticalGroup("ScriptableObjectBaseVertical")]
    [LabelWidth(100)]
    public bool IsPermanent;

    [TextArea]
    [HideLabel]
    [PropertySpace(SpaceBefore = 0, SpaceAfter = 40), PropertyOrder(1)]
    [Title("Description", titleAlignment: TitleAlignments.Centered)]
    public string description;



    [EnumToggleButtons]
    public ItemTypeEnum itemType;

    [ShowIf("itemType", ItemTypeEnum.CacWeapon)]
    public float damageCac;

    [ShowIf("itemType", ItemTypeEnum.CacWeapon)]
    public float reachCac;

    [ShowIf("itemType", ItemTypeEnum.CacWeapon)]
    public float rangeCac;

    [ShowIf("itemType", ItemTypeEnum.CacWeapon)]
    public float cooldownCac;

    [ShowIf("itemType", ItemTypeEnum.CacWeapon)]
    public float ImpactTime;

    [EnumPaging]
    [ShowIf("itemType", ItemTypeEnum.CacWeapon)]
    public impactEffectCacEnum impactEffectCac;

    [ShowIf("itemType", ItemTypeEnum.DistanceWeapon)]
    public float damageDistance;

    [ShowIf("itemType", ItemTypeEnum.DistanceWeapon)]
    public GameObject bulletPrefab;

    [EnumPaging]
    [ShowIf("itemType", ItemTypeEnum.DistanceWeapon)]
    public ImpactEffectDistanceEnum impactEffectDistance;

    [ShowIf("itemType", ItemTypeEnum.DistanceWeapon)]
    public float weaponCooldownDistance;

    [ShowIf("itemType", ItemTypeEnum.ActiveItem)]
    public int numberOfCharges;

    [EnumPaging]
    [ShowIf("itemType", ItemTypeEnum.ActiveItem)]
    public activeItem activeItemName;

    [ShowIf("activeItemName", activeItem.colorBomb)]
    public bool colorBomb;

    [ShowIf("activeItemName", activeItem.MGSBox)]
    public bool MGSBox;

    [ShowIf("activeItemName", activeItem.iceFlower)]
    public bool iceFlower;

    [ShowIf("activeItemName", activeItem.chrono)]
    public bool chrono;

    [ShowIf("activeItemName", activeItem.spinach)]
    public bool spinach;

    [ShowIf("activeItemName", activeItem.mirror)]
    public bool mirror;

    [ShowIf("activeItemName", activeItem.musicBox)]
    public bool musicBox;

    [ShowIf("activeItemName", activeItem.fatherWatch)]
    public bool fatherWatch;

    [ShowIf("activeItemName", activeItem.map)]
    public bool map;

    [ShowIf("activeItemName", activeItem.remote)]
    public bool remote;

    [ShowIf("itemType", ItemTypeEnum.Consumables)]
    [EnumPaging]
    [EnumToggleButtons]
    public ConsumablesTypesEnum consumableType;

    [ShowIf("itemType", ItemTypeEnum.Consumables)]
    [ShowIf("consumableType", ConsumablesTypesEnum.Heal)]
    public int healingPoints;

    [ShowIf("itemType", ItemTypeEnum.Consumables)]
    [ShowIf("consumableType", ConsumablesTypesEnum.Speed)]
    public float speedMultiplication;

    [ShowIf("itemType", ItemTypeEnum.Consumables)]
    [ShowIf("consumableType", ConsumablesTypesEnum.Strengh)]
    public float damageMultiplication;

    [ShowIf("itemType", ItemTypeEnum.Consumables)]
    [ShowIf("consumableType", ConsumablesTypesEnum.Coin)]
    public int coinValue;
}

public enum activeItem
{ 
    colorBomb, MGSBox, iceFlower, chrono, spinach, mirror, musicBox, fatherWatch, map, remote
}

public enum ItemTypeEnum
{
    CacWeapon, DistanceWeapon, Consumables, ActiveItem
}

public enum ImpactEffectDistanceEnum
{
    Freeze, Fire, Poison, Stun, None
}

public enum impactEffectCacEnum
{
    Freeze, Fire, Poison, Stun, None
}

public enum ConsumablesTypesEnum
{
    Heal, Speed, Strengh, Coin
}
