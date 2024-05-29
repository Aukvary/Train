using UnityEngine;
using UnityEngine.SceneManagement;

public class Train : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Health>().OnDieEvent += () => DataManager.GotoMapScene(true);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            GetComponent<Health>().Die();
    }
}