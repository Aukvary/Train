using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    [SerializeField] private Health _heath;

    private Dictionary<Type, Buff> _buffs;

    public float Health
    {
        get => _heath.Score;

        set
        {
            _heath.Score = value;
        }
    }

    public float Damage
    {
        get;
        set;
    }

    private void Awake()
    {
        _buffs = new Dictionary<Type, Buff>();
    }

    public void AddBuff(Func<UnitStats, Buff> addFunc)
    {
        Buff buff = addFunc.Invoke(this);

        if (_buffs.TryAdd(buff.GetType(), buff) == false)
            _buffs[buff.GetType()]++;
    }

    public void RemoveBuff(Func<UnitStats, Buff> removeFunc)
    {
        Buff buff = removeFunc.Invoke(this);

        _buffs.Remove(buff.GetType());
    }
}