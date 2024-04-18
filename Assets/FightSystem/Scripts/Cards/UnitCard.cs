using System;
using UnityEngine;

[Serializable]
public class UnitCard
{
    [SerializeField] private CardRarityTitles _rarity;
    [SerializeField] private string _title;
    [SerializeField] private UnitStats _unitStats;

    private CardRaritySettings _raritySettings;

    public CardRarityTitles rarity;

    public string title => _title;

    public float health => _unitStats.health;
    public float damage => _unitStats.damage;

    public UnitCard()
    {
        _raritySettings = new CardRaritySettings(_rarity);
        _unitStats.GetComponent<Renderer>().material.color = _raritySettings.rarityColor;
    }

    public void SpawnUnit(Vector3 position)
    {
        
    }
}