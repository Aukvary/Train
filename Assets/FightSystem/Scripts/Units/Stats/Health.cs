using System;
using UnityEngine;

public abstract class Health : ScriptableObject, IScorable, IDrawable
{
    [Min(0)]protected float CurrentHealth;

    public event Action<GameObject> OnTakeDamage;
    public event Action<GameObject> OnTakeHeal;

    public abstract float score { get; set; }

    public abstract bool visible { get; set; }

    public abstract void Add(float heal);

    public abstract void Remove(float damage);

    public abstract void Draw();
}
