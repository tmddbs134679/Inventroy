using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _inst;
    public static GameManager Inst { get { return _inst; } }

    public PlayerController player;

    public List<ItemData> defaultPlayerItems;

    private void Awake()
    {
        _inst = this;
    }
}
