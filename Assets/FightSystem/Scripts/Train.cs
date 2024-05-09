using UnityEngine;
using UnityEngine.SceneManagement;

public class Train : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Health>().OnDieEvent += () => SceneManager.LoadScene((int)Scenes.MapScene);
    }
}