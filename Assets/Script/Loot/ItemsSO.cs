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

    [EnumPaging]
    [ShowIf("itemType", ItemTypeEnum.CacWeapon)]
    public impactEffectCacEnum impactEffectCac;

    [ShowIf("itemType", ItemTypeEnum.CacWeapon)]
    public float weaponCooldownCac;

    [ShowIf("itemType", ItemTypeEnum.DistanceWeapon)]
    public float damageDistance;

    [ShowIf("itemType", ItemTypeEnum.DistanceWeapon)]
    public string bulletType;

    [EnumPaging]
    [ShowIf("itemType", ItemTypeEnum.DistanceWeapon)]
    public ImpactEffectDistanceEnum impactEffectDistance;

    [ShowIf("itemType", ItemTypeEnum.DistanceWeapon)]
    public float weaponCooldownDistance;

    [ShowIf("itemType", ItemTypeEnum.DistanceWeapon)]
    public float cooldownDistance;


    [EnumPaging]
    [ShowIf("itemType", ItemTypeEnum.Consumables)]
    public ConsumablesTypesEnum consumablesTypes;


}

public enum ItemTypeEnum
{
    CacWeapon, DistanceWeapon, Consumables
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
    Heal, Speed, Strenght
}
