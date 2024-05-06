using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DeckCardDrawer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _unitCost;

    private Image _spriteRenderer;
    private Button _button;

    private Card _card;

    private Color selectColor => new Color(0.7f, 0.7f, 0.7f);
    private Color unselectColor => Color.white;

    public Card Card
    {
        get => _card;

        set
        {
            _card = value;
            if (value != null)
            {
                _spriteRenderer.sprite = value.Sprite;
                Material = value.Material;
                _unitCost.text = value.Cost.ToString();
            }
            else
            {
                _spriteRenderer.sprite = null;
                Material = null;
                _unitCost.text = " ";
            }

        }
    }

    public Color Color
    {
        get => _spriteRenderer.color;

        private set => _spriteRenderer.color = value;
    }

    public Material Material
    {
        get => _spriteRenderer.material;

        private set => _spriteRenderer.material = value;
    }

    private new RectTransform transform;

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        _spriteRenderer = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    public void AddEventOnClick(UnityAction func) =>
        _button.onClick.AddListener(func);

    public Card Select()
    {
        if (_card == null)
            return null;
        _spriteRenderer.color = selectColor;
        transform.localScale = new Vector2(0.9f, 0.9f);
        return _card;
    }

    public void Unselect()
    {
        _spriteRenderer.color = unselectColor;
        transform.localScale = Vector2.one;
    }
}