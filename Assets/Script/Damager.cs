using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public float damage;

    public enum DamagerTypes
    {
        PlayerCac, PlayerDist, Ennemy
    }

    public DamagerTypes type;

    public float Damage()
    {
        switch (type)
        {
            case DamagerTypes.PlayerCac:
                return PlayerAttack.instance.DamageCaC;
            case DamagerTypes.PlayerDist:
                return PlayerShoot.instance.DamageDist;
            case DamagerTypes.Ennemy:
                return damage;
            default:
                return 0;
                
        }

    }



}
