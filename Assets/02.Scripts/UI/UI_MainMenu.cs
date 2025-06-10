using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenu : UI_Popup
{
    #region Enum

    enum GameObjects
    {
        ExpSlider,
    }
    enum Buttons
    {
        StatusButton,
        InventoryButton,
    }

    enum Images
    {
        PlayerImage,
    }




    enum Texts
    {
        PlayerNameText,
        PlayerLevelText,
        PlayerExpText,
        PlayerDesText,
     //   PlayerGoldText,
    }

    #endregion

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        InitPlayerStat();
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
      
        GetButton((int)Buttons.StatusButton).gameObject.BindEvent(OnClickStatus);
        GetButton((int)Buttons.InventoryButton).gameObject.BindEvent(OnClickInventory);

       
        return true;
    }


    void OnClickStatus()
    {
        UI_Status StatusPopupUI = UIManager.Inst.SceneUI.statusPopupUI;
        StatusPopupUI.SetInfo();
        StatusPopupUI.gameObject.SetActive(true);
    }

    void OnClickInventory()
    {
        UI_Inventory StatusPopupUI = UIManager.Inst.SceneUI.InventorypopupUI;
        StatusPopupUI.SetInfo();
        StatusPopupUI.gameObject.SetActive(true);
    }

    void InitPlayerStat()
    {
        PlayerStat stat = GameManager.Inst.player._playerStat;
        GetText((int)Texts.PlayerNameText).text = stat.Name;
        GetText((int)Texts.PlayerLevelText).text = "Lv :" + stat.Level.ToString();
        GetText((int)Texts.PlayerExpText).text = stat.Exp.ToString();
        GetText((int)Texts.PlayerDesText).text = stat.Des.ToString();
        GetObject((int)GameObjects.ExpSlider).GetComponent<Slider>().value = (float)stat.Exp / 10.0f;
    }

}
