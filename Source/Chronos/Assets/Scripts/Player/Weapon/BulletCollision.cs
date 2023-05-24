using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private int _enemiesBreakthrough = 1;
    private int _damage = 1;

    [SerializeField] private GameObject _effectPrefeb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HitEnemy();
            collision.gameObject.GetComponent<EnemyHealth>().GetDamage(_damage);
        }
    }

    public void HitEnemy()
    {
        _enemiesBreakthrough -= 1;

        if (_enemiesBreakthrough <= 0)
        {
            Remove();
        }
    }

    private void Remove()
    {
        GetComponent<Collider2D>().enabled = false;
        Instantiate(_effectPrefeb, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
