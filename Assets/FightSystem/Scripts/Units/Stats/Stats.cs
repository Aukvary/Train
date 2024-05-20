public class Stats 
{
    public readonly float BaseDamage;

    public readonly float BaseRange;

    public readonly float BaseDelay;

    public readonly float BaseSpeed;

    public readonly Teams Team;

    public Stats(float baseDamage, float baseRange, float baseDelay, float baseSpeed, Teams team)
    {
        BaseDamage = baseDamage;
        BaseRange = baseRange;
        BaseDelay = baseDelay;
        BaseSpeed = baseSpeed;
        Team = team;
    }
}