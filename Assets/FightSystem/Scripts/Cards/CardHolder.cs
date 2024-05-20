using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    [SerializeField] private List<DeckCardDrawer> _cardDrawers;
    [SerializeField] private TextMeshProUGUI _mannaScore;
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _mannaRegen;
    [SerializeField] private float _startManna;

    private CardDeck _cardDeck;

    private (Card card, int index) _selectedCard;

    private float _manna;

    public float Manna
    {
        get => _manna;

        private set
        {
            _manna = Mathf.Clamp(value, 0, 10);
            _mannaScore.text = ((int)_manna).ToString();
        }
    }

    private void Awake()
    {
        _cardDeck = CardDeck.GetNewDeck();
    }

    private void Start()
    {
        foreach (var drawer in _cardDrawers)
        {
            drawer.AddEventOnClick(() =>
            {
                _selectedCard.card = drawer.Select();
                _selectedCard.index = _cardDrawers.IndexOf(drawer);
            });
            drawer.Card = _cardDeck.GetRandomCard();
        }
        Manna = _startManna;
    }

    private void Update()
    {
        HotKeySelect();
        UnselectCard();
        Manna += Time.deltaTime * _mannaRegen;
    }

    private void HotKeySelect()
    {
        KeyCode key = KeyCode.Alpha1;

        foreach(var drawer in _cardDrawers)
        {
            if(Input.GetKeyDown(key))
            {
                ResetSelectCard();
                _selectedCard.card = drawer.Select();
                _selectedCard.index = _cardDrawers.IndexOf(drawer);
            }
            key++;
        }
    }

    private void UnselectCard()
    {
        bool keys = Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) ||
            Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4);
        if (Input.anyKeyDown && Input.GetKeyDown(KeyCode.Mouse0))
        {
            TrySpawn();
            ResetSelectCard();
        }
        else if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0) && !keys)
        {
            ResetSelectCard();

        }
    }

    private void TrySpawn()
    {
        if (_selectedCard.card == null)
            return;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) == false)
            return;
        if (hit.collider.TryGetComponent<GameField>(out _) == false)
            return;
        if (_selectedCard.card.Cost > Manna)
            return;

        Manna -= _selectedCard.card.Cost;
        _selectedCard.card.Spawn(hit.point, Teams.Green, _targets);
        TakeCardFromDeck();

    }

    private void TakeCardFromDeck()
    {
        _cardDrawers[_selectedCard.index].Card = _cardDeck.GetRandomCard();

        ResetSelectCard();
    }

    private void ResetSelectCard()
    {
        foreach (var drawer in _cardDrawers)
        {
            drawer.Unselect();
        }
        _selectedCard = (null, default);
    }
}