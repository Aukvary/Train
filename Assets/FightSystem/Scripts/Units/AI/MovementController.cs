using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerTargetFinder _targetFinder;
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
        _targetFinder = GetComponent<PlayerTargetFinder>();
        _aiAgent.stoppingDistance = GetComponent<AttackController>().Range;
        _aiAgent.speed = _speed;
        _aiAgent.angularSpeed = 0;
    }

    protected void FixedUpdate()
    {
        if (CurrentTarget == null)
        {
            _aiAgent.ResetPath();
            return;
        }

        _aiAgent.SetDestination(CurrentTarget.position);
    }   
}