using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public int enemiesBreakthrough = 1;
    public int damage = 1;

    public GameObject effectPrefeb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HitEnemy();
            collision.gameObject.GetComponent<EnemyHealth>().GetDamage(damage);
        }
    }

    public void HitEnemy()
    {
        enemiesBreakthrough -= 1;

        if (enemiesBreakthrough <= 0)
        {
            Remove();
        }
    }

    private void Remove()
    {
        GetComponent<Collider2D>().enabled = false;
        Instantiate(effectPrefeb, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
