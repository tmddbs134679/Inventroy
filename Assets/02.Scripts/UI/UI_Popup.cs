using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        return true;
       
    }
    public virtual void ClosePopupUI()
    {
        UIManager.Inst.ClosePopupUI(this);
    }




}
