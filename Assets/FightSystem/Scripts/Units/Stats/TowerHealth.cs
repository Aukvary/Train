using UnityEngine;

public class TowerHealth : PlayerHealth
{
    protected override void Awake()
    {
        MaxHealth = Health + Health * PlayerPrefs.GetFloat(nameof(TowerHealth), 0);
        UnitHealth = MaxHealth;
    }
}