using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{
    [SerializeField] private List<DeckCardDrawer> _cardDrawers;
    [SerializeField] private Camera _camera;

    private CardDeck _cardDeck;

    private (Card card, int index) _selectedCard;

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
    }

    private void Update()
    {
        UnselectCard();
    }

    private void UnselectCard()
    {
        if (Input.anyKeyDown && Input.GetKeyDown(KeyCode.Mouse0))
        {
            TrySpawn();
            ResetSelectCard();
        }
        else if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0))
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

        _selectedCard.card.Spawn(hit.point);

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