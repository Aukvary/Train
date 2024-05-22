using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField][Min(0f)] private float _health;

    private float _maxHealth;

    private void Awake()
    {
        _maxHealth = _health;
    }

    public override float UnitHealth
    {
        get => _health;

        set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);
            if (_health == 0)
                Die();
        }
    }
    protected override void Die()
    {
        Destroy(gameObject);
    }
}