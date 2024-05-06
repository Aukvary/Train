using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class MovementController : TargetFinder
{
    [SerializeField] private float _speed;

    private NavMeshAgent _aiAgent;
    private AttackController _attackController;

    private Transform _train;
    private (Transform forward, Transform back) _boxes;

    public void SetTargets(Transform train, (Transform forward, Transform back) boxes)
    {
        _train = train;
        _boxes = boxes;
    }

    protected override void Awake()
    {
        base.Awake();
        _aiAgent = GetComponent<NavMeshAgent>();
        _attackController = GetComponent<AttackController>();
        _aiAgent.stoppingDistance = _attackController.Range;
        _aiAgent.speed = _speed;
        _aiAgent.angularSpeed = 0;
    }

    protected override void FixedUpdate()
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
        if (FindUnit())
            return;

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