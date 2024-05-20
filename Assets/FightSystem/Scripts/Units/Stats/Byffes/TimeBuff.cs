using System.Collections;
using UnityEngine;

public abstract class TimeBuff : Buff
{
    [SerializeField] private float _duration;

    private UnitStats _target;

    public override Buff AddBuff(UnitStats stats)
    {
        stats.StartCoroutine(StartBuff());
        _target = stats;

        return this;
    }

    private IEnumerator StartBuff()
    {
        Implement(_target);
        yield return new WaitForSeconds(_duration);
        _target.UnbuffUnit(RemoveBuff);
    }

    protected abstract void Implement(UnitStats stats);

    public override void ResetBuff()
    {
        Implement(_target);
    }

    public override void StuckBuff()
    {
        _target.StopCoroutine(StartBuff());
        _target.StartCoroutine(StartBuff());
    }
}