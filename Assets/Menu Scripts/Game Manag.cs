using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Quit()
    {
        PlayerPrefs.DeleteAll();
        DataManager.DeleteData();
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MapScene");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene((int)Scenes.Tutorial);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
