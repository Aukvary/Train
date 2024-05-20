using UnityEngine;

[CreateAssetMenu(fileName = "Buffes", menuName = "Buffes/SlowBuff", order = 1)]
public class SlowBuff : TimeBuff
{
    protected override void Implement(UnitStats stats)
    {
        stats.CurrentSpeed *= 0.7f;
    }
}