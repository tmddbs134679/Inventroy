using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainScene : UI_Base
{

   [SerializeField]private UI_Inventory _inventoryPopupUI;
   [SerializeField] private UI_Status _statusPopupUI;

    public UI_Inventory InventorypopupUI { get { return _inventoryPopupUI; } }
    public UI_Status statusPopupUI { get { return _statusPopupUI; } }

    public override bool Init()
    {
        return true;
    }
}
