using UnityEngine;
using UnityEngine.SceneManagement;

public class Stop : MonoBehaviour
{
    public string sceneToLoad;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Game Menu");
    }
}
