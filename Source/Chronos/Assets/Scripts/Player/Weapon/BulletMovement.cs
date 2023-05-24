using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BulletMovement : MonoBehaviour
{
    private float _speed = 1000;
    private float _distance = 500;

    private Vector2 _spawnPosition;
    private Vector2 _direction;

    private void Start()
    {
        _spawnPosition = transform.position;
        _direction = GetNearestEnemyDirection();
    }

    private void FixedUpdate()
    {
        Move();
        CheckTraveledDistance();
    }

    private void Move()
    {
        GetComponent<Rigidbody2D>().velocity = _direction * _speed;
    }

    private void CheckTraveledDistance()
    {
        float currentDistance = Vector2.Distance(_spawnPosition, transform.position);

        if (currentDistance >= _distance)
        {
            Remove();
        }
    }

    private Vector2 GetNearestEnemyDirection()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            Vector2 enemyPosition = enemies[0].transform.position;

            foreach (GameObject enemy in enemies)
            {
                float currentDistance = Vector2.Distance(transform.position, enemyPosition);
                float newDistance = Vector2.Distance(transform.position, enemy.transform.position);

                if (newDistance < currentDistance)
                {
                    enemyPosition = enemy.transform.position;
                }
            }

            return (enemyPosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        }

        return GetRandomDirection(); // if no enemy is in range
    }

    private Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    }

    private void Remove()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject);
    }
}
