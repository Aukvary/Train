using UnityEngine;

[CreateAssetMenu(fileName = "Cards", menuName = "Cards/Card", order = 1)]
public class Card : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private CardRarityTitles _rarity;
    [SerializeField] private Sprite _cardSprite;
    [SerializeField] private CardView _cardView;

    [SerializeField] private UnitStats _unitStats;


    private CardRaritySettings _raritySettings;

    public string Title => _title;
    public CardRaritySettings Rarity => _raritySettings;
    public Sprite Sprite => _cardSprite;

    public UnitStats Unit => _unitStats;

    public float Health => _unitStats.Health;
    public float Damage => _unitStats.Damage;

    public Material Material => _cardView.Material;
    public Color Color => _cardView.Color;

    public void Spawn(Vector3 position)
    {
        Instantiate(_unitStats.gameObject, position + Vector3.up, Quaternion.identity);
    }


    private void Awake()
    {
        _raritySettings = new CardRaritySettings(_rarity);
    }
}