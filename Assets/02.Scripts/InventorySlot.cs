using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class InventorySlot 
{
    public ItemData _itemDataSO;
    public bool _isEquip;
    public bool _isEquipped;

    public InventorySlot(ItemData data, int count = 1)
    {
        _itemDataSO = data;
    }

    void Awake()
    {

    }

}
