using System;
using System.Collections;
using UnityEngine;

public class RangeAttack : AttackController
{
    [SerializeField] protected Bullet _bullet;
    [SerializeField] protected Transform _spawnPosition;

    public Bullet Bullet => _bullet;

    protected override void Attack()
    {
        Bullet.Shoot(_spawnPosition.position, CalculateTime(Target.position), Target);
        StartCoroutine(Shoot(Target.position));
    }

    protected float CalculateTime(Vector3 target) =>
        (target - transform.position).magnitude / Bullet.BulletSpeed;

    protected IEnumerator Shoot(Vector3 target)
    {
        yield return new WaitForSeconds(CalculateTime(target));
        if (Target != null)
        {
            var health = Target.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.Damage(Damage, UnitStats);
            }
        }
    }
}