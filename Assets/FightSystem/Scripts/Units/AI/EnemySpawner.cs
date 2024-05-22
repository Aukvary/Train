using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private float _mannaRegen;

    [Space(30)]

    [SerializeField] private Transform _backRight;
    [SerializeField] private Transform _backLeft;
    [SerializeField] private Transform _forwardRight;
    [SerializeField] private Transform _forwardLeft;

    private List<Card> _cards;

    private float _manna;

    private Transform _lastSpawnPosition;

    public Card Card { get; private set;}

    private void Awake()
    {
        _cards = new List<Card>();
        _manna = 0;

        foreach (Card card in Resources.LoadAll<Card>("Cards"))
            _cards.Add(card);
        Card = _cards[Random.Range(0, _cards.Count)];
    }

    private void Update()
    {
        _manna += Time.deltaTime * _mannaRegen;

        if(_manna >= Card.Cost)
        {
            _manna -= Card.Cost;
            _lastSpawnPosition = _lastSpawnPosition != null ? LeftSpawn() : RightSpaw();
            Card = _cards[Random.Range(0, _cards.Count)];
        }
    }

    private Transform LeftSpawn()
    {
        Transform position = _lastSpawnPosition == _backRight ? _backLeft : _forwardLeft;
        Card.Spawn(position.position, Teams.Red, _targets);
        return null;
    }

    private Transform RightSpaw()
    {
        Transform position = Random.Range(0, 2) == 0 ? _backRight : _forwardRight;
        Card.Spawn(position.position, Teams.Red, _targets);
        return position;
    }
}