using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : UI_Popup
{
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
        //GameManager.Inst.player;
    }

    

}
