using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_EquipItem : UI_Base
{
    InventorySlot data;
    public Action OnClickEquipItem;
    enum GameObjects
    {
        EquippedObject,
    }

    enum Images
    {
        EquipmentImage,
    }

    private void Awake()
    {
        Init();
    }
    public void SetInfo(InventorySlot data ,ScrollRect scrollRect = null)
    {
        this.data = data;
        GetImage((int)Images.EquipmentImage).sprite = data._itemDataSO.image;
            SetInitEquip();
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindImage(typeof(Images));

        gameObject.BindEvent(OnClickEquipItemButton);
        GetObject((int)GameObjects.EquippedObject).SetActive(false);
        return true;
    }

    private void OnClickEquipItemButton()
    {
        data._isEquipped = !data._isEquipped; 
        SetEquipStat();
    }

    private void SetInitEquip()
    {
        if (data._isEquipped)
            GetObject((int)GameObjects.EquippedObject).SetActive(true);
        else
            GetObject((int)GameObjects.EquippedObject).SetActive(false);
     
    }

    private void SetEquipStat()
    {
        if (data._isEquipped)
        {
            GetObject((int)GameObjects.EquippedObject).SetActive(true);
            GameManager.Inst.EquipItem(data);
        }
          
        else
        {
            GetObject((int)GameObjects.EquippedObject).SetActive(false);
            GameManager.Inst.UnEquipItem(data);
        }
           
        
    }
}
