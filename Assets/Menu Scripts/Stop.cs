using UnityEngine;
using UnityEngine.SceneManagement;

public class Stop : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private InventorySystem _inventorySystem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _pauseMenu.SetActive(!_pauseMenu.activeSelf);
    }

    public void Continue()=>
        _pauseMenu.SetActive(!_pauseMenu.activeSelf);

    public void Exit()
    {
        DataManager.SaveData(_inventorySystem, null);
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }
}
