using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManag : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MapScene");
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
