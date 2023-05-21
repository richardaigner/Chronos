using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnemies : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    public void SpawnEnemy()
    {
        enemySpawner.SpawnEnemy();
    }
}
