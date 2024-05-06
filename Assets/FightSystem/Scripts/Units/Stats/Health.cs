using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public abstract float UnitHealth { get; set; }

    public event Action<GameObject> OnTakeDamageEvent;
    public event Action<GameObject> OnTakeHealEvent;
    public event Action OnDieEvent;

    public virtual void Heal(float heal, GameObject healObject)
    {
        UnitHealth += Mathf.Max(heal, 0);
        OnTakeHealEvent?.Invoke(healObject);
    }

    public virtual void Damage(float damage, GameObject enemy)
    {
        UnitHealth -= Mathf.Max(damage, 0);
        OnTakeDamageEvent?.Invoke(enemy);
    }

    protected void InvokeDieEvent() =>
        OnDieEvent?.Invoke();

    protected abstract void Die();
}
