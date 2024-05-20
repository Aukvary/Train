using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cards", menuName = "Cards/Card", order = 1)]
public class Card : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private int _cost;
    [SerializeField] private CardRarityTitles _rarity;
    [SerializeField] private Sprite _cardSprite;
    [SerializeField] private CardView _cardView;

    [SerializeField] private UnitStats _unitStats;

    public int Cost => _cost;
    public string Title => _title;
    public CardRarityTitles Rarity => _rarity;
    public Sprite Sprite => _cardSprite;

    public UnitStats Unit => _unitStats;

    public float Health => _unitStats.CurrentHealth;
    public float Damage => _unitStats.CurrentDamage;

    public Material Material => _cardView.Material;
    public Color Color => _cardView.Color;

    public void Spawn(Vector3 position, Teams team, List<Transform> targets)
    {
        UnitStats unit = Instantiate(_unitStats, position, Quaternion.identity);
        unit.Team = team;

        var targetFinder = unit.GetComponent<PlayerTargetFinder>();

        targetFinder.SetTargets(targets[0], (targets[1], targets[2]));
    }
}