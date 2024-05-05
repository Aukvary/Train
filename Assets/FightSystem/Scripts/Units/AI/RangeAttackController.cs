using System;
using System.Collections;
using UnityEngine;

public class RangeAttackController : AttackController
{
    [SerializeField] private Bullet _bullet;

    public event Action<GameObject> OnAttack;

    protected override void Attack()
    {
        if (Target == null)
            return;
        if (Vector3.Distance(transform.position, Target.position) > Range)
            return;

        _bullet.Shoot(transform.position, CalculateTime(Target.position), Target);
        StartCoroutine(Shoot(Target.position));
    }

    private float CalculateTime(Vector3 target) =>
        (target - transform.position).magnitude / _bullet.BulletSpeed;

    private IEnumerator Shoot(Vector3 target)
    {
        yield return new WaitForSeconds(CalculateTime(target));
        var health = Target.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.Damage(Damege, gameObject);
            OnAttack?.Invoke(health.gameObject);
        }
    }
}