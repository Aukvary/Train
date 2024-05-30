using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public void Click()
    {
        PlayerPrefs.DeleteAll();
        DataManager.DeleteData();
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }
}
