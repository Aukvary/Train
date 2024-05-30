using TMPro;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private float _currentTime;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.loop = false;
    }

    private void Update()
    {
        if (_currentTime < 127f)
        {
            _currentTime += Time.deltaTime;
            return;
        }
        _audioSource.PlayDelayed(30f);
    }
}