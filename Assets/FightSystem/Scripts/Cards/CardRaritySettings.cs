using System;
using UnityEngine;


[Serializable]
public class CardRaritySettings
{
    private CardRarityTitles _rarity;

    public CardRaritySettings(CardRarityTitles title)
    {
        _rarity = title;
    }

    public CardRarityTitles cardRarity => _rarity;
    public int rarityID => (int)cardRarity;

    public Color rarityColor
    {
        get
        {
            return cardRarity switch
            {
                CardRarityTitles.common => Color.white,
                CardRarityTitles.rarity => Color.blue,
                CardRarityTitles.legendary => Color.red,

                _ => throw new UnexistRarityExeption()
            };
        }
    }
}