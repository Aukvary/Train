using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _viewRange;

    private NavMeshAgent _aiAgent;
    private UnitStats _currentUnitStats;

    private Transform _train;
    private (Transform forward, Transform back) _boxes;

    public Transform CurrentTarget { get; private set; }

    public float StopDistance
    {
        get => _aiAgent.stoppingDistance;
        set => Mathf.Max(_aiAgent.stoppingDistance = value, 0);
    }

    public void SetTargets(Transform train, (Transform forward, Transform back) boxes)
    {
        _train = train;
        _boxes = boxes;
    }

    private void Awake()
    {
        _aiAgent = GetComponent<NavMeshAgent>();
        _currentUnitStats = GetComponent<UnitStats>();
        _aiAgent.speed = _speed;
        _aiAgent.angularSpeed = 0;
    }

    private void FixedUpdate()
    {
        SetTarget();
        if (CurrentTarget == null)
        {
            _aiAgent.ResetPath();
            return;
        }

        _aiAgent.SetDestination(CurrentTarget.position);

    }

    private void SetTarget()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, _viewRange);
        if (cols.Length > 0) 
        {
            float minDistane = int.MaxValue;
            Transform target = null;
            foreach (var col in cols)
            {
                var stats = col.GetComponent<UnitStats>();
                if (stats != null && stats.Team != _currentUnitStats.Team)
                {
                    float distance = Vector3.Distance(transform.position, col.transform.position);
                    if (distance < minDistane)
                    {
                        minDistane = distance;
                        target = col.transform;
                    }
                }
            }
            if (target != null)
            {
                var unit = target.GetComponent<UnitStats>();
                if (unit != null)
                {
                    CurrentTarget = target;
                    return;
                }
            }
        }

        if (_boxes.back == null && _boxes.forward == null)
        {
            CurrentTarget = _train;
            return;
        }

        if (_boxes.back == null)
        {
            CurrentTarget = _boxes.forward;
            return;
        }
        if (_boxes.forward == null)
        {
            CurrentTarget = _boxes.back;
            return;
        }

        float distaceForward = Vector3.Distance(transform.position, _boxes.forward.position);
        float distaceBack = Vector3.Distance(transform.position, _boxes.back.position);
        if (distaceBack > distaceForward)
            CurrentTarget = _boxes.forward;
        else
            CurrentTarget = _boxes.back;
    }
}