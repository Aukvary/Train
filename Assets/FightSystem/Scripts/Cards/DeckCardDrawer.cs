using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DeckCardDrawer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _unitCost;
    [SerializeField] private TextMeshProUGUI _unitDamage;
    [SerializeField] private TextMeshProUGUI _unitHealth;
    [SerializeField] private Image _unitSprite;

    private Image _spriteRenderer;
    private Button _button;

    private Card _card;

    private Vector2 _baseScale;

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
                _unitSprite.sprite = value.Sprite;
                Material = value.Material;

                _unitCost.text = value.Cost.ToString();
                _unitDamage.text = value.Damage.ToString();
                _unitHealth.text = value.Health.ToString();
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

        _baseScale = transform.localScale;
    }

    public void AddEventOnClick(UnityAction func) =>
        _button.onClick.AddListener(func);

    public Card Select()
    {
        if (_card == null)
            return null;
        _spriteRenderer.color = selectColor;
        _unitSprite.color = selectColor;
        transform.localScale = new Vector2(1.2f, 1.2f);
        return _card;
    }

    public void Unselect()
    {
        _spriteRenderer.color = unselectColor;
        _unitSprite.color = unselectColor;
        transform.localScale = _baseScale;
    }
}