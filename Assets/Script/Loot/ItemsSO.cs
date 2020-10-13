using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Items")]
public class ItemsSO : ScriptableObject
{
    public string Itemname;
    public Sprite Artwork;
    public int ID;

}
