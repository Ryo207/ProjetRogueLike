using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : Singleton<LootManager>
{
    public List<ItemsSO> lootTables = new List<ItemsSO>();
    

        private void Awake()
        {
          CreateSingleton(true);
        }

    void Start()
    {

    }

}
