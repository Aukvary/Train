using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Buffes", menuName = "Buffes/BleedingBuff", order = 1)]
public class BleedingBuff : TimeBuff
{
    [SerializeField] private float _damageMultiplier;
    [SerializeField] private float _multiplierMultiply;

    public override void StuckBuff()
    {
        base.StuckBuff();
        _damageMultiplier *= _multiplierMultiply;
    }

    public override Buff RemoveBuff(UnitStats stats)
    {
        var health = stats.GetComponent<Health>();

        health.OnTakeDamageEvent -= (UnitStats unit) =>
        {
            float damage = unit.CurrentDamage * _damageMultiplier;
            health.Damage(damage, unit);
        };

        return this;
    }

    protected override void Implement(UnitStats stats)
    {
        return;
        var health = stats.GetComponent<Health>();

        health.OnTakeDamageEvent += (UnitStats unit) =>
        {
            float damage = unit.CurrentDamage * _damageMultiplier;
            health.Damage(damage, unit);
            Debug.Log(damage);
        };
    }
}