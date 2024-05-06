using UnityEngine;

public class MeleeAttackController : AttackController
{
    protected override void Attack()
    {
        if (Target == null)
            return;
        if (Vector3.Distance(transform.position, Target.position) > Range)
            return;

        var health = Target.GetComponent<PlayerHealth>();
        health.Damage(Damege, gameObject);
    }
}