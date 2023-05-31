using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSequence : MonoBehaviour
{
    private float _gameTime = 0;
    private float _nextSpawnTime = 0;
    private float _spawnTimeInterval = 5;
    [SerializeField] private string _levelName;
    private List<EnemySpawnInterval> _spawnIntervals = new List<EnemySpawnInterval>();
    private EnemySpawner _enemySpawner;

    public float GameTime { get { return _gameTime; } }

    private void Start()
    {
        LoadSpawnIntervals();
        _enemySpawner = GetComponent<EnemySpawner>();
    }

    private void Update()
    {
        UpdateTime();
        SpawnEnemies();
    }

    private void UpdateTime()
    {
        _gameTime += Time.deltaTime;
    }

    private void SpawnEnemies()
    {
        if (_gameTime >= _nextSpawnTime)
        {
            _nextSpawnTime += _spawnTimeInterval;

            foreach (EnemySpawnInterval interval in _spawnIntervals)
            {
                if (_gameTime >= interval.NextSpawnTime)
                {
                    interval.NextSpawnTime += interval.SpawnInterval;
                    _enemySpawner.SpawnEnemies(interval.EnemyId, interval.EnemyLevel, interval.EnemyAmount);
                }
            }
        }
    }

    private void LoadSpawnIntervals()
    {
        if (_levelName == "Forest")
        {
            _spawnIntervals.Add(new EnemySpawnInterval("00:00", "03:00", 5, 0, 1, 5));
            _spawnIntervals.Add(new EnemySpawnInterval("00:00", "06:00", 5, 1, 1, 5));
            _spawnIntervals.Add(new EnemySpawnInterval("03:00", "06:00", 5, 0, 2, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("03:00", "09:00", 5, 1, 2, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "09:00", 5, 0, 3, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "12:00", 5, 1, 3, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("09:00", "15:00", 5, 0, 4, 5));
            _spawnIntervals.Add(new EnemySpawnInterval("09:00", "15:00", 5, 1, 4, 5));
            _spawnIntervals.Add(new EnemySpawnInterval("12:00", "15:00", 5, 1, 5, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("12:00", "15:00", 5, 0, 5, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("15:00", "30:00", 5, 0, 6, 5));
            _spawnIntervals.Add(new EnemySpawnInterval("15:00", "30:00", 5, 1, 6, 5));
            _spawnIntervals.Add(new EnemySpawnInterval("15:00", "30:00", 5, 0, 6, 5));
            _spawnIntervals.Add(new EnemySpawnInterval("15:00", "30:00", 5, 1, 6, 5));
        }
    }
}
