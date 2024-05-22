using UnityEngine;

public class FriendFinder : TargetFinder
{
    protected override void FindTarget()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, _viewRange);
        if (cols.Length == 0)
            return;

        float minDistance = int.MaxValue;

        foreach (Collider col in cols)
        {
            var stats = col.GetComponent<UnitStats>();

            if (stats == null || stats.Team != CurrentUnitStats.Team)
                continue;

            var mover = stats.GetComponent<MovementController>();
            if (mover == null)
                continue;

            var healer = stats.GetComponent<HealingAura>();
            if (healer != null)
                continue;

            float distance = Vector3.Distance(stats.transform.position, transform.position);
            if (distance > minDistance)
                continue;

            minDistance = distance;
            CurrentTarget = stats.transform;
        }
        return;
    }
}