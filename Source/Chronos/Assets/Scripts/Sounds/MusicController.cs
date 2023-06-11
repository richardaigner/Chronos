using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private bool _bossMusicActive = false;
    public bool BossMusicActive { get { return _bossMusicActive; } }

    private float _updateCheckCounter = 0;
    private float _updateCheckLength = 1;

    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _bossMusic;

    private void Update()
    {
        _updateCheckCounter -= Time.deltaTime;

        if (_updateCheckCounter < 0)
        {
            _updateCheckCounter += _updateCheckLength;
            AreBossesAlive();
        }
    }

    public void ActivateBossMusic()
    {
        if (!_bossMusicActive)
        {
            _bossMusicActive = true;
            _backgroundMusic.Stop();
            _bossMusic.Play();
        }
    }

    public void DeactivateBossMusic()
    {
        if (_bossMusicActive)
        {
            _bossMusicActive = false;
            _bossMusic.Stop();
            _backgroundMusic.Play();
        }
    }

    public void AreBossesAlive()
    {
        if (GameObject.FindGameObjectWithTag("EnemyBoss") != null)
        {
            ActivateBossMusic();
        }
        else
        {
            DeactivateBossMusic();
        }
    }
}
