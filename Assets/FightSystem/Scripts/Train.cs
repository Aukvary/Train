using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private bool _playerTrain;
    [SerializeField] private bool isBoss;
    private void Awake()
    {
        GetComponent<Health>().OnDieEvent +=()=> DataManager.GotoMapScene(_playerTrain, isBoss);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_playerTrain)
            GetComponent<Health>().Die();
    }
}