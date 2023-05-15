using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject); // bullet get damage
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1); // enemy get damage
        }
    }
}
