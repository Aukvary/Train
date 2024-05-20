using UnityEngine;

public abstract class Buff : ScriptableObject
{
    public int StuckCount {  get; protected set; }

    public Buff() => StuckCount = 0;

    public abstract Buff AddBuff(UnitStats stats);

    public virtual void ResetBuff() { }

    public virtual Buff RemoveBuff(UnitStats stats) => this;

    public virtual void StuckBuff() =>
        StuckCount++;
}