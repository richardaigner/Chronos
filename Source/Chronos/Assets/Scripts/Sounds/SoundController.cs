using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private float _randomPitchMod = 0.1f;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.pitch = Random.Range(_audioSource.pitch - _randomPitchMod, _audioSource.pitch + _randomPitchMod);
    }

    void Update()
    {
        if (!_audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
