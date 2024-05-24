using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private TargetFinder _targetFinder;
    private NavMeshAgent _aiAgent;

    public float Speed
    {
        get => _speed; 
        set 
        {
            if (value < 0)
                return;
            _speed = value;
        }
    }
    public Transform CurrentTarget => _targetFinder.CurrentTarget;

    protected void Awake()
    {
        _aiAgent = GetComponent<NavMeshAgent>();
        _targetFinder = GetComponent<TargetFinder>();
        _aiAgent.stoppingDistance = GetComponent<AttackController>().Range;
        _aiAgent.speed = _speed;
        _aiAgent.angularSpeed = 0;
    }

    protected void FixedUpdate()
    {
        if (CurrentTarget == null)
        {
            _aiAgent.ResetPath();
        }
        else
            _aiAgent.SetDestination(CurrentTarget.position);

        SetAnimation();
    }   

    private void SetAnimation()
    {
        bool state = CurrentTarget != null && _aiAgent.remainingDistance > _aiAgent.stoppingDistance;
        _animator.SetBool("HasPath", state);
    }
}