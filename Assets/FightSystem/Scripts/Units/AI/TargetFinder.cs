using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    [SerializeField] protected float _viewRange;

    public UnitStats CurrentUnitStats { get; private set; }

    public Transform CurrentTarget { get; protected set; }

    protected virtual void Awake()
    {
        CurrentUnitStats = GetComponent<UnitStats>();
    }

    private void FixedUpdate()
    {
            FindTarget();
    }

    protected virtual void FindTarget()
    {
        FindUnit();
    }

    protected bool FindUnit()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, _viewRange);
        if (cols.Length == 0)
            return false;

        float minDistance = int.MaxValue;
        bool found = false;

        foreach (Collider col in cols)
        {
            var stats = col.GetComponent<UnitStats>();

            if (stats == null || stats.Team == CurrentUnitStats.Team)
                continue;

            float distance = Vector3.Distance(stats.transform.position, transform.position);
            if (distance > minDistance)
                continue;

            minDistance = distance;
            CurrentTarget = stats.transform;
            found = true;
        }
        return found;
    }
}