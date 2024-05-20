using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    [SerializeField] private Teams _team;

    private SpriteRenderer _spriteRenderer;

    private AttackController _attackController;
    private MovementController _movementController;
    private Health _health;

    private Stats _baseStats;

    private Dictionary<Type, Buff> _buffes;

    public Teams Team
    {
        get => _team;
        set
        {
            _team = value;

            if (value == Teams.Red)
            {
                _spriteRenderer.color = new Color(0.88f, 0.345f, 0.345f);
            }
            else
            {
                _spriteRenderer.color = new Color(0.796f, 0.973f, 0.647f);
            }
        }
    }

    public float CurrentDamage
    {
        get => _attackController.Damage;

        set => _attackController.Damage = value;
    }

    public float CurrentRange
    {
        get => _attackController.Range;

        set => _attackController.Range = value;
    }

    public float CurrentDelay
    {
        get => _attackController.Delay;

        set => _attackController.Delay = value;
    }

    public float CurrentSpeed
    {
        get => _movementController.Speed;

        set => _movementController.Speed = value;
    }

    public float CurrentHealth
    {
        get => _health.UnitHealth;

        set => _health.UnitHealth = value;
    }

    public Stats BaseStats => _baseStats;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _attackController = GetComponent<AttackController>();
        _movementController = GetComponent<MovementController>();
        _health = GetComponent<Health>();

        _buffes = new Dictionary<Type, Buff>();
        Team = Team;
    }

    private void Start()
    {
        InitBaseStats();
    }

    private void InitBaseStats()
    {
        float damage = _attackController.Damage;
        float range = _attackController.Range;
        float delay = _attackController.Delay;

        if (_movementController != null)
        {
            float speed = _movementController.Speed;
            _baseStats = new Stats(damage, range, delay, speed, Team);
        }
        else
            _baseStats = new Stats(damage, range, delay, 0, Team);
    }

    public void BuffUnit(Func<UnitStats, Buff> addFunc)
    {
        Buff buff = addFunc(this);
        if (_buffes.ContainsKey(buff.GetType()))
        {
            _buffes[buff.GetType()].StuckBuff();
        }
        else
        {
            _buffes.Add(buff.GetType(), buff);
        }
    }


    public void UnbuffUnit(Func<UnitStats, Buff> removeFunc)
    {
        Buff buff = removeFunc(this);
        _buffes.Remove(buff.GetType());
        ResetBuffes();
    }

    private void ResetBuffes()
    {
        CurrentDamage = _baseStats.BaseDamage;
        CurrentRange = _baseStats.BaseRange;
        CurrentDelay = _baseStats.BaseDelay;

        if(_movementController != null) 
            CurrentSpeed = _baseStats.BaseSpeed;

        foreach (var buff in _buffes)
        {
            buff.Value.ResetBuff();
        }
    }
}