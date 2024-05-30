using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class DataManager
{
    private static Vector3 _lastPosition =  Vector3.zero;
    private static string _currentEnemy;

    public static Dictionary<string, bool> EnemyTrains = new Dictionary<string, bool>();

    public static Vector3 LastPosition => _lastPosition;

    public static void GoToFightScene(InventorySystem invenory, string train)
    {
        SaveData(invenory, train);
        SceneManager.LoadScene((int)Scenes.FightScene);
    }

    public static void GoToBossScene(InventorySystem invenory, string train)
    {
        SaveData(invenory, train);
        SceneManager.LoadScene((int)Scenes.BossScene);
    }

    public static void SaveData(InventorySystem invenory, string train)
    {
        _lastPosition = invenory.transform.position;
        _currentEnemy = train;

        foreach (var item in invenory.item)
        {
            PlayerPrefs.SetInt(item.name, item.quantity);
        }
    }

    public static void GotoMapScene(bool win, bool isBoss = false)
    {
        if (win)
        {
            EnemyTrains[_currentEnemy] = false;
        }
        else
        {
            EnemyTrains[_currentEnemy] = true;
            _lastPosition = Vector3.zero;
        }
        _currentEnemy = null;
        if (isBoss)
            SceneManager.LoadScene((int)Scenes.Final);
        else
            SceneManager.LoadScene((int)Scenes.MapScene);
    }

    public static void DeleteData()
    {
        EnemyTrains.Clear();
        _lastPosition = Vector3.zero;
    }
}