using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objs = new Dictionary<Type, UnityEngine.Object[]>();


    public virtual bool Init()
    {

        return true;
    }

    private void Start()
    {
        Init();
    }

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objs = new UnityEngine.Object[names.Length];
        _objs.Add(typeof(T), objs);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objs[i] = Util.FindChild(gameObject, names[i], true);
            else
                objs[i] = Util.FindChild<T>(gameObject, names[i], true);
            if (objs[i] == null)
                Debug.Log($"Failed to bind({names[i]})");
        }
    }
    protected void BindObject(Type type) { Bind<GameObject>(type); }
    protected void BindImage(Type type) { Bind<Image>(type); }
    protected void BindText(Type type) { Bind<TMP_Text>(type); }
    protected void BindButton(Type type) { Bind<Button>(type); }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objs.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idx] as T;
    }

    public static void BindEvent(GameObject go, Action action = null, Action<BaseEventData> dragAction = null, EUIEvent type = EUIEvent.CLICK)
    {
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

        switch (type)
        {
            case EUIEvent.CLICK:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case EUIEvent.PRESSED:
                evt.OnPressedHandler -= action;
                evt.OnPressedHandler += action;
                break;
            case EUIEvent.POINTERDOWN:
                evt.OnPointerDownHandler -= action;
                evt.OnPointerDownHandler += action;
                break;
            case EUIEvent.POINTERUP:
                evt.OnPointerUpHandler -= action;
                evt.OnPointerUpHandler += action;
                break;
        }
    }
}
