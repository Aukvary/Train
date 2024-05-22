using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField][Min(0f)] protected float Health;

    protected float MaxHealth;

    protected virtual void Awake()
    {
        MaxHealth = Health;
    }

    public override float UnitHealth
    {
        get => Health;

        set
        {
            Health = Mathf.Clamp(value, 0, MaxHealth);
            if (Health == 0)
                Die();
        }
    }
    protected override void Die()
    {
        Destroy(gameObject);
    }
}