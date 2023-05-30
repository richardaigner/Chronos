using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool _active = true;
    private float _spawnTimer = 1.0f;
    private float _timeCounter = 1.0f;

    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject[] _enemyPrefabs;

    public void Update()
    {
        if (_active)
        {
            _timeCounter -= Time.deltaTime;

            if (_timeCounter < 0.0f)
            {
                _timeCounter += _spawnTimer;
                SpawnEnemy();
            }
        }
    }

    public void SpawnEnemy()
    {
        int enemyId = Random.Range(0, _enemyPrefabs.Length);

        if (_enemyPrefabs.Length > 0 )
        {
            Instantiate(_enemyPrefabs[enemyId], _camera.transform.position + GetSpawnPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetSpawnPosition()
    {
        Vector2 randomPosition;

        if (Random.Range(0, 2) == 0) // x oder y
        {
            if (Random.Range(0, 2) == 0)
            {
                randomPosition = new Vector3(0, -550, 0);
            }
            else
            {
                randomPosition = new Vector3(0,  550, 0);
            }

            randomPosition = new Vector3(Random.Range(-1100, 1100), randomPosition.y, 0);
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                randomPosition = new Vector3(-1000, 0, 0);
            }
            else
            {
                randomPosition = new Vector3( 1000, 0, 0);
            }

            randomPosition = new Vector3(randomPosition.x, Random.Range(-600, 600), 0);
        }

        return randomPosition;
    }
}
