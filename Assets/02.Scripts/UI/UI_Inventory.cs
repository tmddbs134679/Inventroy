using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : UI_Popup
{

    enum GameObjects
    {
        InventoryContentObject,
    }
    enum Buttons
    {
        BackButton,
    }
    private void Awake()
    {
        Init();
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;


        BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));
        GetButton((int)Buttons.BackButton).gameObject.BindEvent(OnClickBackButton);
        gameObject.SetActive(false);
        return true;
    }

    private void OnClickBackButton()
    {
        gameObject.SetActive(false);
    }

    public void SetInfo()
    {
        Refresh();

        GameObject Container = GetObject((int)GameObjects.InventoryContentObject);
        List<InventorySlot> Is = GameManager.Inst.player._inventory.items;

        foreach (InventorySlot slot in Is)
        {
            UI_EquipItem item = UIManager.Inst.MakeSubItem<UI_EquipItem>(Container.transform);
            item.SetInfo(slot);
        }
    }

    private void Refresh()
    {
        if (_init == false)
            return;

        GetObject((int)GameObjects.InventoryContentObject).DestroyChilds();
    }
}
