using System;
using System.Collections.Generic;

[Serializable]
public class CardDeck
{
    private Dictionary<CardRarityTitles, List<UnitCard>> _cardsInPool;

    [NonSerialized]
    private List<UnitCard> _cardsOnTable;

    public CardDeck()
    {
        _cardsInPool = new Dictionary<CardRarityTitles, List<UnitCard>>();
        _cardsOnTable = new List<UnitCard>();
    }

    public int count => _cardsInPool.Count;

    public IEnumerable<UnitCard> this[CardRarityTitles rarity]
    {
        get
        {
            List<UnitCard> cards;
            if(_cardsInPool.TryGetValue(rarity, out cards))
            {
                return cards;
            }

            return null;
        }
    }


    public UnitCard GetRandomCard()
    {
        return null;
    }

    public UnitCard GetCardOfRarity(CardRarityTitles rarity)
    {
        return null;
    }

    public void Reset()
    {
        foreach (UnitCard card in _cardsOnTable)
        {
            _cardsInPool[card.rarity].Add(card);
        }

        _cardsOnTable.Clear();
    }
}