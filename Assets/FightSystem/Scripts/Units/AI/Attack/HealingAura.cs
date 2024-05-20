using System.Collections.Generic;
using UnityEngine;

public class HealingAura : AttackController
{
    [SerializeField] private float _healingRange;
    protected override void Attack()
    {
        List<Collider> cols = new List<Collider>(Physics.OverlapSphere(transform.position, _healingRange));

        for(int i = cols.Count - 1; i >= 0; i--)
        {
            var unit = cols[i].GetComponent<UnitStats>();
            
            if(unit == null || unit.Team == UnitStats.Team)
                continue;

            unit.CurrentHealth += Damage;
        }
    }
}