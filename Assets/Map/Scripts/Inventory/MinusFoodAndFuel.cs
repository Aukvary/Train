using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusFoodAndFuel : MonoBehaviour
{
    private InventorySystem _inventorySystem;

    private void Start()
    {
        _inventorySystem = GetComponent<InventorySystem>();
    }

    public void FoodAndFuelMinus(int i,int number)
    {
        if (number == 0)
        {
            _inventorySystem.item[number].quantity -= (i - PlayerPrefs.GetInt("fuelMinus"));
        }
        if (number == 4)
        {
            _inventorySystem.item[number].quantity -= (i - PlayerPrefs.GetInt("foodMinus"));
        }
    }
}
