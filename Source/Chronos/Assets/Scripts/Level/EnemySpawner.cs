using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnBorderUp = 1000;
    [SerializeField] private float _spawnBorderRight = 2000;
    [SerializeField] private float _spawnBorderDown = -1000;
    [SerializeField] private float _spawnBorderLeft = -2000;

    [SerializeField] private Vector2 _spawnRangeHorizontal;
    [SerializeField] private Vector2 _spawnRangeVertical;

    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject[] _enemyPrefabs;

    public void SpawnEnemies(int enemyId, int enemyHealth, int enemyAmount)
    {
        Vector2 spawnPosition = _camera.transform.position + GetSpawnPosition();

        for (int i = 0; i < enemyAmount; i++)
        {
            if (_enemyPrefabs.Length > 0)
            {
                int spawnField = 100;
                Vector2 mod = new Vector2(Random.Range(-spawnField, spawnField), Random.Range(-spawnField, spawnField));
                GameObject enemy = Instantiate(_enemyPrefabs[enemyId], spawnPosition + mod, Quaternion.identity);
                enemy.GetComponent<EnemyController>().Health = enemyHealth;
            }
        }
    }

    private Vector3 GetSpawnPosition()
    {
        Vector2 randomPosition = Vector2.zero;

        bool positionFound = false;
        while (!positionFound)
        {
            int rndDirectionSelect = Random.Range(0, 3);

            if (rndDirectionSelect == 0 && !(_playerTransform.position.y > _spawnBorderUp))
            {
                float minRange = _spawnRangeHorizontal.x;
                float maxRange = _spawnRangeHorizontal.y;

                // left or right
                if (_playerTransform.position.x < _spawnBorderLeft)
                {
                    minRange = 0;
                }
                else if (_playerTransform.position.x > _spawnBorderRight)
                {
                    maxRange = 0;
                }

                randomPosition = new Vector2(Random.Range(minRange, maxRange), 600);
                positionFound = true;
            }
            else if (rndDirectionSelect == 1 && !(_playerTransform.position.x > _spawnBorderRight))
            {
                float minRange = _spawnRangeVertical.x;
                float maxRange = _spawnRangeVertical.y;

                // up or down
                if (_playerTransform.position.y < _spawnBorderDown)
                {
                    minRange = 0;
                }
                else if (_playerTransform.position.y > _spawnBorderUp)
                {
                    maxRange = 0;
                }

                randomPosition = new Vector2(1100, Random.Range(minRange, maxRange));
                positionFound = true;
            }
            else if (rndDirectionSelect == 2 && !(_playerTransform.position.y < _spawnBorderDown))
            {
                float minRange = _spawnRangeHorizontal.x;
                float maxRange = _spawnRangeHorizontal.y;

                // left or right
                if (_playerTransform.position.x < _spawnBorderLeft)
                {
                    minRange = 0;
                }
                else if (_playerTransform.position.x > _spawnBorderRight)
                {
                    maxRange = 0;
                }

                randomPosition = new Vector2(Random.Range(minRange, maxRange), -600);
                positionFound = true;
            }
            else if (rndDirectionSelect == 3 && !(_playerTransform.position.x < _spawnBorderLeft))
            {
                float minRange = _spawnRangeVertical.x;
                float maxRange = _spawnRangeVertical.y;

                // up or down
                if (_playerTransform.position.y < _spawnBorderDown)
                {
                    minRange = 0;
                }
                else if (_playerTransform.position.y > _spawnBorderUp)
                {
                    maxRange = 0;
                }

                randomPosition = new Vector2(-1100, Random.Range(minRange, maxRange));
                positionFound = true;
            }
        }
        
        return randomPosition;
    }
}
