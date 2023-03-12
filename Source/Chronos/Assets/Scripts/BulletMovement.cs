using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BulletMovement : MonoBehaviour
{
    public float speed = 1000;
    Vector2 direction;

    void Start()
    {
        direction = GetNearestEnemyDirection();
        //GetComponent<Rigidbody2D>().velocity = GetNearestEnemyDirection() * speed;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    Vector2 GetNearestEnemyDirection()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject.Find("InfoText").gameObject.GetComponent<Text>().text = enemies.Length.ToString();

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


            Debug.Log((enemyPosition - new Vector2(transform.position.x, transform.position.y)).normalized);
            return (enemyPosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        }

        Debug.Log("random");
        return GetRandomDirection();
    }

    Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    }
}
