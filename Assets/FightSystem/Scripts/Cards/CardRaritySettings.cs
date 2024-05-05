using System;
using Unity.Mathematics;
using UnityEngine;


[Serializable]
public class CardRaritySettings
{
    private CardRarityTitles _rarity;

    public CardRaritySettings(CardRarityTitles title)
    {
        _rarity = title;
    }

    public CardRarityTitles CardRarity => _rarity;
    public int RrarityID => (int)CardRarity;

    public Color RarityColor
    {
        get
        {
            return CardRarity switch
            {
                CardRarityTitles.common => Color.white,
                CardRarityTitles.rarity => Color.blue,
                CardRarityTitles.legendary => Color.red,

                _ => throw new UnexistRarityExeption()
            };
        }
    }
}