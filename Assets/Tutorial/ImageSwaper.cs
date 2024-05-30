using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageSwaper : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objects;

    private int _index;

    private void Awake()
    {
        foreach (var obj in _objects)
        {
            obj.SetActive(false);
        }
        _index = 0;
        _objects[_index].SetActive(true);
    }

    private void Update()
    {
        if (!Input.anyKeyDown)
            return;
        _objects[_index].SetActive(false);
        _index++;
        if (_index == _objects.Count)
        {
            SceneManager.LoadScene((int)Scenes.MainMenu);
            return;
        }
        _objects[_index].SetActive(true);
    }
}