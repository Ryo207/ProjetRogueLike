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

    [ShowIf("itemType", ItemTypeEnum.ActiveItem)]
    public bool colorBomb;

    [ShowIf("itemType", ItemTypeEnum.ActiveItem)]
    public bool MGSBox;

    [ShowIf("itemType", ItemTypeEnum.ActiveItem)]
    public bool iceFlower;

    [ShowIf("itemType", ItemTypeEnum.ActiveItem)]
    public bool chrono;

    [ShowIf("itemType", ItemTypeEnum.ActiveItem)]
    public bool spinach;

    [ShowIf("itemType", ItemTypeEnum.ActiveItem)]
    public bool mirror;

    [ShowIf("itemType", ItemTypeEnum.ActiveItem)]
    public bool musicBox;

    [ShowIf("itemType", ItemTypeEnum.ActiveItem)]
    public bool fatherWatch;

    [ShowIf("itemType", ItemTypeEnum.ActiveItem)]
    public bool map;

    [ShowIf("itemType", ItemTypeEnum.ActiveItem)]
    public bool remote;

    [EnumPaging]
    [ShowIf("itemType", ItemTypeEnum.Consumables)]
    [EnumToggleButtons]
    public ConsumablesTypesEnum consumableType;

    [EnumPaging]
    [ShowIf("consumableType", ConsumablesTypesEnum.Heal)]
    public int healingPoints;

    [EnumPaging]
    [ShowIf("consumableType", ConsumablesTypesEnum.Speed)]
    public float speedMultiplication;

    [EnumPaging]
    [ShowIf("consumableType", ConsumablesTypesEnum.Strengh)]
    public float damageMultiplication;

    [EnumPaging]
    [ShowIf("consumableType", ConsumablesTypesEnum.Coin)]
    public int coinValue;
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
