using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private EnemyMovement _enemyMovement;

    private void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 playerDirection = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<PlayerHealth>().GetDamage(this.GetComponent<EnemyWeapon>().Damage, playerDirection);

            Vector2 enemyDirection = (transform.position - collision.transform.position).normalized;
            _enemyMovement.Knockback(enemyDirection, 1000);
        }
    }
}
