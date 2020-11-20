using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public ItemsSO item;

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
        item = GenerateRandomItem();
        spriteRenderer.sprite = item.Artwork;

    }

    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>())
        {

        }
    }
}
