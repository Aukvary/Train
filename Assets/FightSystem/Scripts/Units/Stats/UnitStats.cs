using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    [SerializeField] private Teams _team;
    [SerializeField] private SpriteRenderer _teamBanner;

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
            _teamBanner.color = _team == Teams.Red?
                new Color(0.878f, 0.345f, 0.345f) : new Color(0.7f, 0.972f, 0.6f);

            if (_movementController == null)
                return;
            if (value == Teams.Red && transform.localScale.x > 0)
            {
                Vector3 bas = transform.localScale;
                bas[0] *= -1;
                transform.localScale = bas;
            }
            else if(value == Teams.Red && transform.localScale.x < 0)
            {
                Vector3 bas = transform.localScale;
                bas[0] *= -1;
                transform.localScale = bas;
            }
        }
    }

    public float CurrentDamage
    {
        get
        {
            if(_attackController == null)
                return GetComponent<AttackController>().Damage;
            return _attackController.Damage;
        }

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
        get
        {
            if(_health == null)
                return GetComponent<PlayerHealth>().UnitHealth;
            return _health.UnitHealth;
        }

        set => _health.UnitHealth = value;
    }

    public Stats BaseStats => _baseStats;

    private void Awake()
    {
        _attackController = GetComponent<AttackController>();
        _movementController = GetComponent<MovementController>();
        _health = GetComponent<Health>();

        _buffes = new Dictionary<Type, Buff>();

        InitBaseStats();
        Team = Team;
    }

    private void InitBaseStats()
    {
        float damage = 0;
        float range = 0;
        float delay = 0;

        if(_attackController)
            damage = _attackController.Damage;
        if(_attackController)
            range = _attackController.Range;
        if(_attackController)
            delay = _attackController.Delay;

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

    internal void UnbuffAllUnit()
    {
        if (_buffes.Count == 0)
            return;

        _buffes.Clear();
        ResetBuffes();
    }
}