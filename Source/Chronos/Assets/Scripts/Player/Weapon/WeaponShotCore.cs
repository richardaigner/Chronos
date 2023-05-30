using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponShotCore : MonoBehaviour
{
    private int _damage = 1;
    private bool _piercing = true;

    [SerializeField] private bool _lifetimeActive = false;
    [SerializeField] private float _lifetimeCounter = 0;

    [SerializeField] private GameObject _effectPrefeb;

    private void Update()
    {
        if (_lifetimeActive)
        {
            if (_lifetimeCounter > 0)
            {
                _lifetimeCounter -= Time.deltaTime;
            }
            else
            {
                Remove();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HitEnemy();
            collision.gameObject.GetComponent<EnemyHealth>().GetDamage(_damage);
        }
    }

    public void SetStats(int damage, bool piercing)
    {
        _damage = damage;
        _piercing = piercing;
    }

    public void HitEnemy()
    {
        Instantiate(_effectPrefeb, transform.position, Quaternion.identity);

        if (!_piercing)
        {
            Remove();
        }
    }

    private void Remove()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject);
    }
}
