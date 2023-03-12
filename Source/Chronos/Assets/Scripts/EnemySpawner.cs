using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    bool active = true;
    float spawnTimer = 1.0f;
    float timeCounter = 1.0f;
    public GameObject enemyPrefab;

    void Update()
    {
        if (active)
        {
            timeCounter -= Time.deltaTime;

            if (timeCounter < 0.0f)
            {
                timeCounter += spawnTimer;
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, GetSpawnPosition(), Quaternion.identity);
    }

    Vector2 GetSpawnPosition()
    {
        Vector2 randomPosition;

        if (Random.Range(0, 2) == 0) // x oder y
        {
            if (Random.Range(0, 2) == 0)
            {
                randomPosition = new Vector2(0, -550);
            }
            else
            {
                randomPosition = new Vector2(0,  550);
            }

            randomPosition = new Vector2(Random.Range(-1000, 1000), randomPosition.y);
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                randomPosition = new Vector2(-1000, 0);
            }
            else
            {
                randomPosition = new Vector2( 1000, 0);
            }

            randomPosition = new Vector2(randomPosition.x, Random.Range(-550, 550));
        }

        return randomPosition;
    }

    public void IncreaseEnemySpawn(float amount)
    {
        spawnTimer -= amount;
    }
}
