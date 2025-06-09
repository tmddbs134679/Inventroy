using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Data/PlayerStatData")]
public class PlayerStatData : ScriptableObject
{
    public string playerName;
    public string Des;
    public int Level;
    public int Exp;
    public float HP;
    public float Atk;
    public float Def;
    public float Cri;
}


[CreateAssetMenu(menuName = "Data/ItemData")]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public string Des;
    public Image image;
}

public static class Util
{

    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }
}

public static class Ex
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
    {
        return Util.GetOrAddComponent<T>(go);
    }

}