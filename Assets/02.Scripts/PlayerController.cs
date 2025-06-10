using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[Serializable]
public class PlayerStat
{
    public string Name;
    public string Des;
    public int Level;
    public int Exp;
    public float Atk;
    public float MaxHp;
    public float Hp;
    public float Def;
    public float Cri;

}
public class PlayerController : MonoBehaviour
{
    public PlayerStat _playerStat = new PlayerStat();

    public PlayerStatData _playerstatSO;

    public Inventory _inventory;

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        InitsStat();
        _inventory = gameObject.GetOrAddComponent<Inventory>();
    }

    public void InitsStat()
    {
       _playerStat.Name = _playerstatSO.playerName;
        _playerStat.Atk = _playerstatSO.Atk;
       _playerStat.Des = _playerstatSO.Des;
       _playerStat.Level = _playerstatSO.Level;
       _playerStat.Hp = _playerstatSO.HP;
       _playerStat.Cri = _playerstatSO.Cri;
       _playerStat.Exp = _playerstatSO.Exp;
    }





}
