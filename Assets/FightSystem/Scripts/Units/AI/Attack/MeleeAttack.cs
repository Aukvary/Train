public class MeleeAttack : AttackController
{
    protected override void Attack()
    {
        var health = Target.GetComponent<PlayerHealth>();
        if(health != null) 
            health.Damage(Damage, UnitStats);
    }
}