using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]private List<InventorySlot> items = new List<InventorySlot>();
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        List<ItemData> defaultItems = GameManager.Inst.defaultPlayerItems;

        foreach(ItemData item in defaultItems)
        {
            AddItem(item);
        }
    }


    public void AddItem(ItemData newItem)
    {
        InventorySlot existing = items.Find(s => s._itemDataSO == newItem);
        if (existing == null)
            items.Add(new InventorySlot(newItem));

    }

    public void Equip()
    {

    }

    public void UnEquip()
    {

    }
}
