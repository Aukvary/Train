using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCardHolder : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private float _delay;

    List<Card> _cards;

    private void Awake()
    {
        _cards = new List<Card>();
        foreach (Card card in Resources.LoadAll<Card>("Cards"))
            _cards.Add(card);
    }

    private void Start()
    {
        StartCoroutine(SpawnUnit());
    }

    private IEnumerator SpawnUnit()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);

            int index = Random.Range(0, _cards.Count);

            Card card = _cards[index];

            card.Spawn(_spawnPosition.position, Teams.Red, _targets);
        }

    }
}