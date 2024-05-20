using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] int maxQuslityItem;

    public List<Item> item;

    private void Update()
    {
        for(int i = 0; i < item.Count; i++)
        {
            item[i].textQuantity.text = item[i].quantity.ToString();
        }
    }
}
