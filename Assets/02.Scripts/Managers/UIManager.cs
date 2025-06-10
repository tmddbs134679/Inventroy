using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager _inst;
    public static UIManager Inst { get { return _inst; } }

    [SerializeField]UI_MainScene _sceneUI = null;
    public UI_MainScene SceneUI { get { return _sceneUI; } }

    public GameObject ItemObj;
    private void Awake()
    {
        _inst = this;
       
    }


    int _order = 10;
    int _toastOrder = 500;

    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    }
    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed!");
            return;
        }
        ClosePopupUI();
    }

    private void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        popup = null;
        _order--;
    }

    public void SetCanvas(GameObject go, bool sort = true, int sortOrder = 0, bool isToast = false)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        if (canvas == null)
        {
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.overrideSorting = true;
        }

        CanvasScaler cs = go.GetOrAddComponent<CanvasScaler>();
        if (cs != null)
        {
            cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            cs.referenceResolution = new Vector2(1920, 1080);
        }

        go.GetOrAddComponent<GraphicRaycaster>();

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = sortOrder;
        }

        if (isToast)
        {
            _toastOrder++;
            canvas.sortingOrder = _toastOrder;
        }

    }
    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Instantiate(ItemObj);

        go.transform.SetParent(parent, false);
        return Util.GetOrAddComponent<T>(go);
    }
}