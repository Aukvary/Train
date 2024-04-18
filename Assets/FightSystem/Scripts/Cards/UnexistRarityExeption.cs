using System;

public class UnexistRarityExeption : Exception
{
    public override string Message =>
        "You select Unexist Rarity for your card";
}