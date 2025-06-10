using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : UI_Popup
{
    #region Enum

    enum GameObjects
    {
        PlayerObject,
        StatusObject,
        InventoryObject,
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
        PlayerGoldText,
    }

    #endregion

    private void Awake()
    {
        Init();
    }

    public override bool Init()
    {

       // BindObject(typeof(GameObjects));
        BindButton(typeof(Buttons));
       // BindText(typeof(Texts));
      //  BindImage(typeof(Images));

        //GetObject((int)GameObjects.InventoryObject).gameObject.SetActive(false);
        //GetObject((int)GameObjects.StatusObject).gameObject.SetActive(false);
        GetButton((int)Buttons.StatusButton).gameObject.BindEvent(OnClickStatus);
        GetButton((int)Buttons.InventoryButton).gameObject.BindEvent(OnClickInventory);


        //GetButton((int)Buttons.BackButton).gameObject.SetActive(false);
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
}
