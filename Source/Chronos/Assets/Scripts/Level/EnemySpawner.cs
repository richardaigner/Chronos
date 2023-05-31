using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject[] _enemyPrefabs;

    public void SpawnEnemies(int enemyId, int enemyLevel, int enemyAmount)
    {
        Vector2 spawnPosition = _camera.transform.position + GetSpawnPosition();

        for (int i = 0; i < enemyAmount; i++)
        {
            if (_enemyPrefabs.Length > 0)
            {
                int spawnField = 100;
                Vector2 mod = new Vector2(Random.Range(-spawnField, spawnField), Random.Range(-spawnField, spawnField));
                GameObject enemy = Instantiate(_enemyPrefabs[enemyId], spawnPosition + mod, Quaternion.identity);
                enemy.GetComponent<EnemyLevel>().SetLevel(enemyLevel);
            }
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
