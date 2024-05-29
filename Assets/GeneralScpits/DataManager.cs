using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class DataManager
{
    private static List<Item> _items;
    private static Vector3 _lastPosition =  Vector3.zero;
    private static string _currentEnemy;

    public static Dictionary<string, bool> EnemyTrains = new Dictionary<string, bool>();

    public static List<Item> Items => _items;
    public static Vector3 LastPosition => _lastPosition;

    public static void GoToFightScene(InventorySystem invenory, string train)
    {
        _items = invenory.item;
        _lastPosition = invenory.transform.position;
        _currentEnemy = train;

        SceneManager.LoadScene((int)Scenes.FightScene);
    }

    public static void GotoMapScene(bool win)
    {
        if (win)
        {
            EnemyTrains[_currentEnemy] = false;
        }
        else
            EnemyTrains[_currentEnemy] = true;
        _currentEnemy = null;
        SceneManager.LoadScene((int)Scenes.MapScene);
    }

    public static void DeleteData()
    {
        _items = null;
        _lastPosition = Vector3.zero;
    }
}