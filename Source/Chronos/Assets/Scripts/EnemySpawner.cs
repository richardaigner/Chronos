using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool active = true;
    private float spawnTimer = 1.0f;
    private float timeCounter = 1.0f;

    public Camera cam;
    public GameObject enemyPrefab;

    public void Update()
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

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, cam.transform.position + GetSpawnPosition(), Quaternion.identity);
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
