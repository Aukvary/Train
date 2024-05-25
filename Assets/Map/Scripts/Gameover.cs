using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public void Click()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
