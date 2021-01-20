using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public ItemsSO _Scriptable;

    public SpriteRenderer spriteRenderer;

    public bool isConstant;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private ItemsSO GenerateRandomItem()
    {
        return LootManager.Instance.lootTables[Random.Range(0, LootManager.Instance.lootTables.Count)];
        
    }

    private ItemsSO ConstantItem()
    {
        return LootManager.Instance.lootTables[0];
    }

    void Start()
    {
        if(isConstant == true)
        {
            ConstantItem();
        }
        else
        {
            _Scriptable = GenerateRandomItem();
        }
        spriteRenderer.sprite = _Scriptable.Artwork;

    }

}
