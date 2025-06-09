using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;

    public PlayerController player;

    public List<ItemData> defaultPlayerItems;

    private void Awake()
    {
        Inst = this;
    }
}
