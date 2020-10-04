using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private int damage = 10;

    public enum DamagerTypes
    {
        PlayerCac, PlayerDist, Ennemy

    }

    public DamagerTypes type = DamagerTypes.Ennemy;

    public int Damage()
    {
        switch (type)
        {
            case DamagerTypes.PlayerCac:
                return PlayerController.instance.DamageCaC;
            case DamagerTypes.PlayerDist:
                return PlayerController.instance.DamageDist;
            case DamagerTypes.Ennemy:
                return damage;
            default:
                return 0;
                
        }

    }



}
