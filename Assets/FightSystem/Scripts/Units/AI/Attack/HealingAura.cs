using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
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
            
            if(unit == null || unit.Team != UnitStats.Team)
                continue;

            var mover = unit.GetComponent<MovementController>();
            if (mover == null)
                continue;

            var healer = unit.GetComponent<HealingAura>();
            if (healer != null)
                continue;

            unit.CurrentHealth += Damage;
        }
    }
}