using UnityEngine;

[CreateAssetMenu(fileName = "View", menuName = "Cards/CardView", order = 1)]
public class CardView : ScriptableObject
{
    [SerializeField] private Material _cardMaterial;
    [SerializeField] private Color _cardColor;

    public Material Material => _cardMaterial;
    public Color Color => _cardColor;
}