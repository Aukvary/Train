using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelApply : MonoBehaviour
{
    public enum Level
    {
        XPTower1, XPTower2, XPTower3,hod,fuelAndFood1, fuelAndFood2, resourse1, resourse2
    }

    [SerializeField] Level level;

    private bool isClick = false;

    public void LevelPlus()
    {
        if(level == Level.XPTower1)
        {
            PlayerPrefs.SetInt("XPTower1Button", 1);
            PlayerPrefs.SetFloat(nameof(TowerHealth), 0.05f);
        }
        if (level == Level.XPTower2 && PlayerPrefs.GetInt("XPTower1Button") == 1)
        {
            PlayerPrefs.SetInt("XPTower2Button", 1);
            PlayerPrefs.SetFloat(nameof(TowerHealth), 0.1f);
        }
        if (level == Level.XPTower3 && PlayerPrefs.GetInt("XPTower2Button") == 1)
        {
            PlayerPrefs.SetInt("XPTower3Button", 1);
            PlayerPrefs.SetFloat(nameof(TowerHealth), 0.12f);
        }
        if (level == Level.hod)
        {
            PlayerPrefs.SetInt("hodDistanse", 16);
            PlayerPrefs.SetInt("hodButton", 1);
        }
        if (level == Level.fuelAndFood1)
        {
            PlayerPrefs.SetInt("fuelAndFood1Button", 1);
            PlayerPrefs.SetInt("foodMinus", 1);
        }
        if (level == Level.fuelAndFood2 && PlayerPrefs.GetInt("fuelAndFood1Button") == 1)
        {
            PlayerPrefs.SetInt("fuelAndFood2Button", 1);
            PlayerPrefs.SetInt("fuelMinus", 1);
        }
        if (level == Level.resourse1)
        {
            PlayerPrefs.SetInt("resourse1Button", 1);
            PlayerPrefs.SetFloat("resourseDrop", 25);
        }
        if (level == Level.resourse2 && PlayerPrefs.GetInt("resourse1Button") == 1)
        {
            PlayerPrefs.SetInt("resourse2Button", 1);
            PlayerPrefs.SetFloat("resourseDrop", 50);
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
    }
}
