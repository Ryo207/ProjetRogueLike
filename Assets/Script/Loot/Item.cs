using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public ItemsSO _Scriptable;

    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private ItemsSO GenerateRandomItem()
    {
        return LootManager.Instance.lootTables[Random.Range(0, LootManager.Instance.lootTables.Count)];
        
    }

    void Start()
    {
        _Scriptable = GenerateRandomItem();
        spriteRenderer.sprite = _Scriptable.Artwork;

    }

}
