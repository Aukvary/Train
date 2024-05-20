using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public abstract float UnitHealth { get; set; }

    public event Action<UnitStats> OnTakeDamageEvent;
    public event Action OnDieEvent;

    public virtual void Damage(float damage, UnitStats enemy)
    {
        UnitHealth -= Mathf.Max(damage, 0);
        OnTakeDamageEvent?.Invoke(enemy);
    }

    protected void InvokeDieEvent() =>
        OnDieEvent?.Invoke();

    protected abstract void Die();
}
