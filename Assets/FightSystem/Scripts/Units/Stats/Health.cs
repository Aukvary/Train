using System;
using UnityEngine;

public abstract class Health : ScriptableObject, IScorable<float>
{
    [Min(0)]protected float CurrentHealth;

    public float Score { get; set; }

    public event Action<GameObject> OnTakeDamage;
    public event Action<GameObject> OnTakeHeal;

    public abstract void AddScore(float heal);

    public abstract void RemoveScore(float damage);
}
