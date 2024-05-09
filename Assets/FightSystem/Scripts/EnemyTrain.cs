using UnityEngine;
using UnityEngine.SceneManagement;

class EnemyTrain : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene((int)Scenes.FightScene);
    }
}