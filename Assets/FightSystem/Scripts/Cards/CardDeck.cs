using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

[Serializable]
public class CardDeck
{
    private Dictionary<CardRarityTitles, List<Card>> _cardsInPool;

    public IEnumerable<Card> this[CardRarityTitles rarity]
    {
        get
        {
            List<Card> cards;

            if (_cardsInPool.TryGetValue(rarity, out cards))
                return cards;

            return null;
        }
    }

    private CardDeck()
    {
        _cardsInPool = new Dictionary<CardRarityTitles, List<Card>>
        {
            { CardRarityTitles.common, new List<Card>() },
            { CardRarityTitles.rarity, new List<Card>() },
            { CardRarityTitles.legendary, new List<Card>() }
        };
    }

    public static CardDeck GetNewDeck(bool resetDeck = false)
    {
        var deck = new CardDeck();

        foreach(Card card in Resources.LoadAll<Card>("Cards"))
            deck.AddCardToDeck(card);

        if(resetDeck)
            PlayerPrefs.SetString(nameof(CardDeck), deck.ToString());

        return deck;
    }

    public Card GetRandomCard()
    {
        int chance = Random.Range(1, 101);
        
        CardRarityTitles cardType;

        if (chance % 26 == 0)
            cardType = CardRarityTitles.legendary;
        else if (chance % 7 == 0)
            cardType = CardRarityTitles.rarity;
        else
            cardType = CardRarityTitles.common;



        if (_cardsInPool[cardType].Count == 0)
            return GetRandomCard();

        int index = Random.Range(0, _cardsInPool[cardType].Count);

        return _cardsInPool[cardType][index];
    }

    public void AddCardToDeck(Card card)
    {
        _cardsInPool[card.Rarity].Add(card);
    }

    public override string ToString()
    {
        return JsonUtility.ToJson(this);
    }
}