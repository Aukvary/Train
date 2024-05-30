using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoursesMinus : MonoBehaviour
{
    [SerializeField] int woodQuantity;
    [SerializeField] int ironQuantity;

    private InventorySystem _inventorySystem;

    private void Start()
    {
        _inventorySystem = FindObjectOfType<InventorySystem>();
    }
    public void Click()
    {
        //if(_inventorySystem.item[1].quantity>=woodQuantity)
    }

}
