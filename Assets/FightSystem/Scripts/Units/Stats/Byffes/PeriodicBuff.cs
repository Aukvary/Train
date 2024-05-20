using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PeriodicBuff : TimeBuff
{
    [SerializeField, Min(0)] private float _duration;

    [SerializeField, Min(0)] private float _frequency;

    protected float _currentTime;

    private UnitStats _target;

    public override Buff AddBuff(UnitStats stats)
    {
        _target = stats;
        stats.StartCoroutine(ImplementBuff());
        return this;
    }

    public IEnumerator ImplementBuff()
    {
        while(true)
        {
            if (_currentTime > _duration)
                break;
            _currentTime += Time.deltaTime;

            DoAction(_target);

            yield return new WaitForSeconds(_frequency);
        }
        _target.UnbuffUnit(RemoveBuff);
    }

    public override void ResetBuff()
    {
        DoAction(_target);
    }

    protected abstract void DoAction(UnitStats stats);
}