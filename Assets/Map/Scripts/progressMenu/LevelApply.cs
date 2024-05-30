using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelApply : MonoBehaviour
{
    public enum Level
    {
        XPTower1, XPTower2, XPTower3,hod,fuelAndFood1, fuelAndFood2, resourse1, resourse2
    }

    private bool isResourseHave = false;

    [SerializeField] int woodQuantity;
    [SerializeField] int ironQuantity;

    [SerializeField] Level level;

    private bool isClick = false;
    private InventorySystem _inventorySystem;

    private void Start()
    {
        _inventorySystem = FindObjectOfType<InventorySystem>();
    }

    public void LevelPlus()
    {
        bool isResourse = isResourseHave;

        if(level == Level.XPTower1 && isResourse)
        {
            PlayerPrefs.SetInt("XPTower1Button", 1);
            PlayerPrefs.SetFloat(nameof(TowerHealth), 0.05f);
            ResourseMinnus();
        }
        if (level == Level.XPTower2 && PlayerPrefs.GetInt("XPTower1Button") == 1 && isResourse)
        {
            PlayerPrefs.SetInt("XPTower2Button", 1);
            PlayerPrefs.SetFloat(nameof(TowerHealth), 0.1f);
            ResourseMinnus();
        }
        if (level == Level.XPTower3 && PlayerPrefs.GetInt("XPTower2Button") == 1 && isResourse)
        {
            PlayerPrefs.SetInt("XPTower3Button", 1);
            PlayerPrefs.SetFloat(nameof(TowerHealth), 0.15f);
            ResourseMinnus();
        }
        if (level == Level.hod && isResourse == true)
        {
            PlayerPrefs.SetInt("hodDistanse", 16);
            PlayerPrefs.SetInt("hodButton", 1);
            ResourseMinnus();
        }
        if (level == Level.fuelAndFood1 && isResourse)
        {
            PlayerPrefs.SetInt("fuelAndFood1Button", 1);
            PlayerPrefs.SetInt("foodMinus", 1);
            ResourseMinnus();
        }
        if (level == Level.fuelAndFood2 && PlayerPrefs.GetInt("fuelAndFood1Button") == 1 && isResourse)
        {
            PlayerPrefs.SetInt("fuelAndFood2Button", 1);
            PlayerPrefs.SetInt("fuelMinus", 1);
            ResourseMinnus();
        }
        if (level == Level.resourse1 && isResourse)
        {
            PlayerPrefs.SetInt("resourse1Button", 1);
            PlayerPrefs.SetFloat("resourseDrop", 25);
            ResourseMinnus();
        }
        if (level == Level.resourse2 && PlayerPrefs.GetInt("resourse1Button") == 1 && isResourse)
        {
            PlayerPrefs.SetInt("resourse2Button", 1);
            PlayerPrefs.SetFloat("resourseDrop", 50);
            ResourseMinnus();
        }
    }


    private void Update()
    {
        if (level == Level.XPTower1 && PlayerPrefs.GetInt("XPTower1Button") == 1)
        {
            gameObject.SetActive(false);
        }
        if (level == Level.XPTower2 && PlayerPrefs.GetInt("XPTower2Button") == 1)
        {
            gameObject.SetActive(false);
        }
        if (level == Level.XPTower3 && PlayerPrefs.GetInt("XPTower3Button") == 1)
        {
            gameObject.SetActive(false);
        }
        if (level == Level.hod && PlayerPrefs.GetInt("hodButton") == 1)
        {
            gameObject.SetActive(false);
        }
        if (level == Level.fuelAndFood1 && PlayerPrefs.GetInt("fuelAndFood1Button") == 1)
        {
            gameObject.SetActive(false);
        }
        if (level == Level.fuelAndFood2 && PlayerPrefs.GetInt("fuelAndFood2Button") == 1)
        {
            gameObject.SetActive(false);
        }
        if (level == Level.resourse1 && PlayerPrefs.GetInt("resourse1Button") == 1)
        {
            gameObject.SetActive(false);
        }
        if (level == Level.resourse2 && PlayerPrefs.GetInt("resourse2Button") == 1)
        {
            gameObject.SetActive(false);
        }

        if (_inventorySystem.item[1].quantity >= woodQuantity && _inventorySystem.item[3].quantity >= ironQuantity)
            isResourseHave = true;
    }

    public void ResourseMinnus()
    {
        _inventorySystem.item[1].quantity -= woodQuantity;
        _inventorySystem.item[3].quantity -= ironQuantity;
    }
}
