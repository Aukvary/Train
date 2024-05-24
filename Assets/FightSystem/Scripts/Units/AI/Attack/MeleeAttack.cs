public class MeleeAttack : AttackController
{
    protected override void Attack()
    {
        var health = Target.GetComponent<PlayerHealth>();
        health.Damage(Damage, UnitStats);
    }
}