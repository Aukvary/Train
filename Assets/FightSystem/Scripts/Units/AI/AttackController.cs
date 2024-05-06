using System.Collections;
using UnityEngine;

public abstract class AttackController : MonoBehaviour
{
    [SerializeField, Min(0)] private float _damage;
    [SerializeField, Min(0)] private float _delay;
    [SerializeField, Min(0)] private float _range;

    private TargetFinder _targetFinder;

    public float Damege
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

        StartCoroutine(SetAttack());
    }
    private IEnumerator SetAttack()
    {
        while(true)
        {
            yield return new WaitForSeconds(Delay);
            Attack();
        }
    }

    protected abstract void Attack();
}