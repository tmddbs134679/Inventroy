using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Status : UI_Popup
{
    enum Buttons
    {
        BackButton,
    }

    enum Texts
    {
        AttackValueText,
        DefenceValueText,
        HealthValueText,
        CriticalValueText,
    }
    
    private void Awake()
    {
        Init();
    }

    public override bool Init()
    {
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));

        GetButton((int)Buttons.BackButton).gameObject.BindEvent(OnClickBackButton);
        gameObject.SetActive(false);
        return true;
    }

    public void SetInfo()
    {
        PlayerStat st = GameManager.Inst.player._playerStat;
        GetText((int)Texts.AttackValueText).text = st.Atk.ToString();
        GetText((int)Texts.DefenceValueText).text = st.Def.ToString();
        GetText((int)Texts.CriticalValueText).text = st.Cri.ToString();
    }

    private void OnClickBackButton()
    {
        gameObject.SetActive(false);
    }
}
