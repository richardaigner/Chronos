using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSequence : MonoBehaviour
{
    private bool _active = true;
    [SerializeField] private int _levelNumber = 0;

    private bool _levelFinished = false;
    private int _enemiesToKill = 0;
    private float _levelFinishedTimerCounter = 0;
    private float _levelFinishedTimerLength = 0.5f;
    [SerializeField] private GameObject _fireworksEffectPrefab;

    private float _gameTime = 0;
    private float _nextSpawnTime = 0;
    private float _spawnTimeInterval = 5;

    private float _difficult01 = 0.4f;
    private float _difficult02 = 0.6f;
    private float _difficult03 = 0.8f;

    private int _collectedKeys = 3; // level win condition
    public int CollectedKeys { get { return _collectedKeys; } set { _collectedKeys = value; } }

    [SerializeField] private string _levelName;
    [SerializeField] private GameController _gameController;
    [SerializeField] private DataController _dataController;

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

            if (_collectedKeys <= 0)
            {
                _dataController.LevelProgress = _levelNumber;
                _dataController.SaveData();
                _gameController.SetLevelFinished();
                _levelFinished = true;
                StopTime();
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                _enemiesToKill = 10 + enemies.Length / 2;
            }
        }

        if (_levelFinished)
        {
            _levelFinishedTimerCounter -= Time.deltaTime;

            if (_levelFinishedTimerCounter < 0)
            {
                _levelFinishedTimerCounter += _levelFinishedTimerLength;
                Instantiate(_fireworksEffectPrefab, new Vector2(Random.Range(-900, 900), Random.Range(-500, 500)), Quaternion.identity);
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                if (enemies.Length > 0)
                {
                    for (int i = 0; i < _enemiesToKill && i < enemies.Length; i++)
                    {
                        if (enemies[i] != null)
                        {
                            enemies[i].GetComponent<EnemyController>().GetDamage(100000, Vector2.zero, 0);
                        }
                    }
                }
            }
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
            _collectedKeys = 8;
            float difficult = _difficult01;

            _spawnIntervals.Add(new EnemySpawnInterval("00:00", "03:00", 5, 0, (int)(20 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("00:00", "06:00", 5, 1, (int)(20 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("01:00", "04:00", 5, 0, (int)(30 * difficult), 10));

            _spawnIntervals.Add(new EnemySpawnInterval("02:00", "02:00", 5, 4, (int)(1000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("02:00", "05:00", 5, 1, (int)(40 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("03:00", "06:00", 5, 0, (int)(50 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("03:00", "09:00", 5, 1, (int)(60 * difficult), 20));

            _spawnIntervals.Add(new EnemySpawnInterval("04:00", "04:00", 5, 4, (int)(2000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("04:00", "07:00", 5, 0, (int)(70 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("05:00", "08:00", 5, 0, (int)(80 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("05:00", "09:00", 5, 1, (int)(360 * difficult), 20));

            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "06:00", 5, 4, (int)(4000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "09:00", 5, 0, (int)(100 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "12:00", 5, 1, (int)(120 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("07:00", "10:00", 5, 1, (int)(140 * difficult), 10));

            _spawnIntervals.Add(new EnemySpawnInterval("08:00", "08:00", 5, 4, (int)(6000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("08:00", "08:00", 5, 4, (int)(6000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("08:00", "11:00", 5, 0, (int)(160 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("09:00", "15:00", 5, 0, (int)(200 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("09:00", "15:00", 5, 1, (int)(220 * difficult), 20));

            _spawnIntervals.Add(new EnemySpawnInterval("10:00", "10:00", 5, 5, (int)(20000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("10:00", "20:00", 5, 0, (int)(240 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("10:00", "20:00", 5, 1, (int)(300 * difficult), 20));
        }
        else if (_levelName == "Corridor")
        {
            _collectedKeys = 8;
            float difficult = _difficult02;

            _spawnIntervals.Add(new EnemySpawnInterval("00:00", "03:00", 5, 2, (int)(20 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("00:00", "06:00", 5, 3, (int)(20 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("01:00", "04:00", 5, 2, (int)(30 * difficult), 10));

            _spawnIntervals.Add(new EnemySpawnInterval("02:00", "02:00", 5, 4, (int)(1000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("02:00", "05:00", 5, 3, (int)(40 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("03:00", "06:00", 5, 2, (int)(50 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("03:00", "09:00", 5, 3, (int)(60 * difficult), 20));

            _spawnIntervals.Add(new EnemySpawnInterval("04:00", "04:00", 5, 4, (int)(2000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("04:00", "07:00", 5, 3, (int)(70 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("05:00", "08:00", 5, 3, (int)(80 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("05:00", "09:00", 5, 2, (int)(360 * difficult), 20));

            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "06:00", 5, 4, (int)(4000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "09:00", 5, 2, (int)(100 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "12:00", 5, 3, (int)(120 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("07:00", "10:00", 5, 3, (int)(140 * difficult), 10));

            _spawnIntervals.Add(new EnemySpawnInterval("08:00", "08:00", 5, 4, (int)(6000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("08:00", "08:00", 5, 4, (int)(6000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("08:00", "11:00", 5, 2, (int)(160 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("09:00", "15:00", 5, 2, (int)(200 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("09:00", "15:00", 5, 3, (int)(220 * difficult), 20));

            _spawnIntervals.Add(new EnemySpawnInterval("10:00", "10:00", 5, 5, (int)(20000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("10:00", "20:00", 5, 2, (int)(240 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("10:00", "20:00", 5, 3, (int)(300 * difficult), 20));
        }
        else if (_levelName == "Arena")
        {
            _collectedKeys = 8;
            float difficult = _difficult03;

            _spawnIntervals.Add(new EnemySpawnInterval("00:00", "03:00", 5, 1, (int)(20 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("00:00", "06:00", 5, 3, (int)(20 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("01:00", "04:00", 5, 2, (int)(30 * difficult), 10));

            _spawnIntervals.Add(new EnemySpawnInterval("02:00", "02:00", 5, 4, (int)(1000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("02:00", "05:00", 5, 0, (int)(40 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("03:00", "06:00", 5, 2, (int)(50 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("03:00", "09:00", 5, 1, (int)(60 * difficult), 20));

            _spawnIntervals.Add(new EnemySpawnInterval("04:00", "04:00", 5, 4, (int)(2000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("04:00", "07:00", 5, 3, (int)(70 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("05:00", "08:00", 5, 0, (int)(80 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("05:00", "09:00", 5, 2, (int)(360 * difficult), 20));

            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "06:00", 5, 4, (int)(4000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "09:00", 5, 3, (int)(100 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("06:00", "12:00", 5, 1, (int)(120 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("07:00", "10:00", 5, 0, (int)(140 * difficult), 10));

            _spawnIntervals.Add(new EnemySpawnInterval("08:00", "08:00", 5, 4, (int)(6000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("08:00", "08:00", 5, 4, (int)(6000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("08:00", "11:00", 5, 2, (int)(160 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("09:00", "15:00", 5, 3, (int)(200 * difficult), 10));
            _spawnIntervals.Add(new EnemySpawnInterval("09:00", "15:00", 5, 1, (int)(220 * difficult), 20));

            _spawnIntervals.Add(new EnemySpawnInterval("10:00", "10:00", 5, 5, (int)(20000 * difficult), 1));
            _spawnIntervals.Add(new EnemySpawnInterval("10:00", "20:00", 5, 2, (int)(240 * difficult), 20));
            _spawnIntervals.Add(new EnemySpawnInterval("10:00", "20:00", 5, 3, (int)(300 * difficult), 20));
        }
    }
}
