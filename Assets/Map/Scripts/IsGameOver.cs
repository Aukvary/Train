using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOvermenu;

    [SerializeField] List<GameObject> closeMenu;

    private InventorySystem _inventorySystem;


    private void Start()
    {
        _inventorySystem = FindObjectOfType<InventorySystem>();      
    }
    public void Update()
    {
        if(_inventorySystem.item[0].quantity <= 0 || _inventorySystem.item[4].quantity <= 0)
        {
            for (int i = 0; i < closeMenu.Count; i++)
            {
                closeMenu[i].SetActive(false);
                gameOvermenu.SetActive(true);
            }
        }
    }
}
