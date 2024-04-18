public abstract class Buff
{
    public abstract Buff AddBuff(UnitStats stats);

    public abstract Buff RemoveBuff(UnitStats stat);

    protected virtual Buff StuckBuff() =>
        this;

    public static Buff operator++(Buff buff) =>
        buff.StuckBuff();
}