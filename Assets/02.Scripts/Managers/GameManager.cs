using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEditor.Progress;

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



    public void EquipItem(InventorySlot item)
    {
         player._playerStat.Atk += item._itemDataSO.AttackBonus;
         player._playerStat.Def += item._itemDataSO.DefenceBonus;
         player._playerStat.Cri += item._itemDataSO.CriticalBonus;
    
    }

    public void UnEquipItem(InventorySlot item)
    {
        player._playerStat.Atk -= item._itemDataSO.AttackBonus;
        player._playerStat.Def -= item._itemDataSO.DefenceBonus;
        player._playerStat.Cri -= item._itemDataSO.CriticalBonus;

    }
}
