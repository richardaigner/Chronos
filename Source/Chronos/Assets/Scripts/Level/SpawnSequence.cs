using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSequence : MonoBehaviour
{
    private bool _active = true;
    
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
        if (_active)
        {
            UpdateTime();
            SpawnEnemies();
        }
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
                    _enemySpawner.SpawnEnemies(interval.EnemyId, interval.EnemyHealth, interval.EnemyAmount);

                    if (interval.EnemyId == 4 || interval.EnemyId == 5)
                    {
                        GameObject.Find("MainCamera").GetComponent<CameraController>().StartScreenShake(0.5f, 0.05f, 30);
                    }
                }
            }

            for (int i = _spawnIntervals.Count - 1; i >= 0; i--)
            {
                if (_gameTime >= _spawnIntervals[i].EndTime)
                {
                    _spawnIntervals.RemoveAt(i);
                }
            }
        }
    }

    public void StopTime()
    {
        _active = false;
    }

    private void LoadSpawnIntervals()
    {
        if (_levelName == "Forest")
        {
            _spawnIntervals.Add(new EnemySpawnInterval("00:00", "03:00", 5, 0,    20, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("00:00", "06:00", 5, 1,    20, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("01:00", "04:00", 5, 0,    30, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("02:00", "05:00", 5, 1,    40, 20));

            _spawnIntervals.Add(new EnemySpawnInterval("03:00", "03:00", 5, 4,   400,  1));
            _spawnIntervals.Add(new EnemySpawnInterval("03:00", "06:00", 5, 0,    50, 20));
            _spawnIntervals.Add(new EnemySpawnInterval("03:00", "09:00", 5, 1,    60, 20));
            _spawnIntervals.Add(new EnemySpawnInterval("04:00", "07:00", 5, 0,    70, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("05:00", "08:00", 5, 0,    80, 20));

            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "06:00", 5, 4,  1000,  1));
            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "09:00", 5, 0,   100, 20));
            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "12:00", 5, 1,   120, 20));
            _spawnIntervals.Add(new EnemySpawnInterval("07:00", "10:00", 5, 1,   140, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("08:00", "11:00", 5, 0,   160, 20));

            _spawnIntervals.Add(new EnemySpawnInterval("09:00", "09:00", 5, 4,  1500,  1));
            _spawnIntervals.Add(new EnemySpawnInterval("09:00", "15:00", 5, 0,   200, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("09:00", "15:00", 5, 1,   220, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("10:00", "13:00", 5, 0,   240, 20));
            _spawnIntervals.Add(new EnemySpawnInterval("11:00", "14:00", 5, 1,   240, 30));

            _spawnIntervals.Add(new EnemySpawnInterval("12:00", "12:00", 5, 4,  3000,  1));
            _spawnIntervals.Add(new EnemySpawnInterval("12:00", "12:00", 5, 4,  3000,  1));
            _spawnIntervals.Add(new EnemySpawnInterval("12:00", "15:00", 5, 1,   300, 20));
            _spawnIntervals.Add(new EnemySpawnInterval("12:00", "15:00", 5, 0,   330, 30));
            _spawnIntervals.Add(new EnemySpawnInterval("13:00", "30:00", 5, 1,   360, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("14:00", "30:00", 5, 0,   390, 20));

            _spawnIntervals.Add(new EnemySpawnInterval("15:00", "15:00", 5, 5, 20000,  1));
            _spawnIntervals.Add(new EnemySpawnInterval("15:00", "30:00", 5, 0,   400, 10));
            _spawnIntervals.Add(new EnemySpawnInterval("15:00", "30:00", 5, 1,   400, 20));
            _spawnIntervals.Add(new EnemySpawnInterval("15:00", "30:00", 5, 0,   400, 20));
            _spawnIntervals.Add(new EnemySpawnInterval("15:00", "30:00", 5, 1,   400, 30));
        }
    }
}
