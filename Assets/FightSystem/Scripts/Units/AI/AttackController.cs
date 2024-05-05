using System.Collections;
using UnityEngine;

[RequireComponent(typeof(UnitStats))]
public abstract class AttackController : MonoBehaviour
{
    [SerializeField, Min(0)] private float _damege;
    [SerializeField, Min(0)] private float _delay;
    [SerializeField, Min(0)] private float _range;

    private MovementController _controller;

    public float Damege
    {
        get => _damege;
        set => _damege = value;
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

    protected Transform Target => _controller.CurrentTarget;


    private void Awake()
    {
        _controller = GetComponent<MovementController>();
        _controller.StopDistance = Range;

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