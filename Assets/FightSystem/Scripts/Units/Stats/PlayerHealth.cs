using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField][Min(0f)] private float _health;

    public override float UnitHealth
    {
        get => _health;

        set
        {
            _health = value;
            if (_health <= 0)
                Die();
        }
    }
    protected override void Die()
    {
        Destroy(gameObject);
    }
}