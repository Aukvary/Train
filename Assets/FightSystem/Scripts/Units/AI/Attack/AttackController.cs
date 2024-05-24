using System.Collections;
using UnityEngine;

public abstract class AttackController : MonoBehaviour
{
    [SerializeField, Min(0)] private float _damage;
    [SerializeField, Min(0)] private float _delay;
    [SerializeField, Min(0)] private float _range;
    [SerializeField] private Buff _attackBuff;

    [Space(30)]

    [SerializeField] private Animator _animator;

    private TargetFinder _targetFinder;

    protected UnitStats UnitStats;

    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }
    public float Delay
    {
        get => _delay;
        set => _delay = value;
    }

    public float Range
    {
        get => _range;
        set => _range = value;
    }

    protected Transform Target => _targetFinder.CurrentTarget;


    private void Awake()
    {
        _targetFinder = GetComponent<TargetFinder>();
        UnitStats = GetComponent<UnitStats>();
    }

    private void Start()
    {
        StartCoroutine(SetAttack());
    }
    private IEnumerator SetAttack()
    {
        while (true)
        {
            if (Target == null || Vector3.Distance(transform.position, Target.position) > Range)
            {
                yield return null;
                continue;
            }
            _animator.SetTrigger("Attack");
            Attack();
            SetBuff(Target.GetComponent<UnitStats>());
            yield return new WaitForSeconds(Delay);
        }
    }

    protected void SetBuff(UnitStats unit)
    {
        if (_attackBuff == null || unit == null)
            return;


        unit.BuffUnit(_attackBuff.AddBuff);
    }
    protected abstract void Attack();
}