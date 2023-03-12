using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnemies : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    public void IncreaseEnemySpawnSpeed()
    {
        enemySpawner.IncreaseEnemySpawn(0.05f);
    }

}
