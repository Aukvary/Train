using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Buffes", menuName = "Buffes/BleedingBuff", order = 1)]
public class BleedingBuff : TimeBuff
{
    [SerializeField] private float _damageMultiplier;
    [SerializeField] private float _multiplierMultiply;

    private float _multiplier;

    private void Awake()
    {
        _multiplier = _damageMultiplier;
    }

    public override void StuckBuff()
    {
        base.StuckBuff();
        _multiplier *= _multiplierMultiply;
    }

    public override Buff RemoveBuff(UnitStats stats)
    {
        if (stats == null)
            return this;
        var health = stats.GetComponent<Health>();

        health.OnTakeDamageEvent -= (UnitStats unit) =>
        {
            float damage = unit.CurrentDamage * _multiplier;
            health.Damage(damage, unit);
        };

        return this;
    }

    protected override void Implement(UnitStats stats)
    {
        var health = stats.GetComponent<Health>();

        health.OnTakeDamageEvent += (UnitStats unit) =>
        {
            float damage = unit.CurrentDamage * _multiplier;
            health.UnitHealth -= damage;
        };
    }
}