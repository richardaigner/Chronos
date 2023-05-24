using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnemies : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    public void SpawnEnemy()
    {
        _enemySpawner.SpawnEnemy();
    }
}
