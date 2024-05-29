using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] int maxQuslityItem;

    public List<Item> item;

    private void Start()
    {
        if(DataManager.Items != null)
        {
            print(DataManager.Items.Count);
            item = DataManager.Items;
            transform.position = DataManager.LastPosition;
        }
    }

    private void Update()
    {
        for(int i = 0; i < item.Count; i++)
        {
            if (item[i].quantity > maxQuslityItem)
            {
                item[i].quantity = maxQuslityItem;
            }
            item[i].textQuantity.text = item[i].quantity.ToString();
        }
    }
}
