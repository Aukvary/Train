using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class DataManager
{
    private static List<Item> _items;
    private static Vector3 _lastPosition;

    public static List<Item> Items => _items;
    public static Vector3 LastPosition => _lastPosition;

    public static void GoToFightScene(InventorySystem invenory)
    {
        _items = invenory.item;
        invenory.transform.position = _lastPosition;

        SceneManager.LoadScene((int)Scenes.FightScene);
    }

    public static void GotoMapScene()
    {
        SceneManager.LoadScene((int)Scenes.MapScene);
    }

    public static void DeleteData()
    {
        _items = null;
        _lastPosition = default;
    }
}