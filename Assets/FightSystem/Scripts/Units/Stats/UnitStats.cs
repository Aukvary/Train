using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(MovementController))]
public class UnitStats : MonoBehaviour
{
    private Teams _team;

    private Health _heath;

    private AttackController _attackController;

    private Dictionary<Type, Buff> _buffs;

    private SpriteRenderer _spriteRenderer;

    public Teams Team
    {
        get => _team;
        set
        {
            _team = value;

            if(value == Teams.Red)
                _spriteRenderer.color = new Color(0.88f, 0.345f, 0.345f);
            else
                _spriteRenderer.color = new Color(0.796f, 0.973f, 0.647f);
        }
    }

    public float Health
    {
        get => _heath.UnitHealth;

        set
        {
            _heath.UnitHealth = value;
        }
    }

    public float Damage
    {
        get => _attackController.Damege;

        set => _attackController.Damege = value;
    }

    public float Delay
    {
        get => _attackController.Delay; 
        set => _attackController.Delay = value;
    }
    public float Range
    {
        get => _attackController.Range; 
        set => _attackController.Range = value;
    }

    private void Awake()
    {
        _buffs = new Dictionary<Type, Buff>();
        _heath = GetComponent<Health>();
        _attackController = GetComponent<AttackController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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