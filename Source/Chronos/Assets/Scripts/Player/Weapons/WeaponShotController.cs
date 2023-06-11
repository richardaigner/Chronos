using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotController : MonoBehaviour
{
    private int _damage = 10;
    private bool _piercing = true;
    private bool _bouncing = false;

    private float _damageIntervalCounter = 0;
    private float _damageIntervalLength = 0.05f;

    private bool _lifetimeActive = false;
    private float _lifetimeCounter = 0;

    private float _knockbackForce = 5000;

    private WeaponShotMovement _movement;
    [SerializeField] private GameObject _effectPrefeb;
    [SerializeField] private GameObject _soundPrefab;

    private void Start()
    {
        _movement = GetComponent<WeaponShotMovement>();

        if (_soundPrefab != null)
        {
            Instantiate(_soundPrefab, transform.position, Quaternion.identity);
        }
    }

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

        if (_damageIntervalCounter > 0)
        {
            _damageIntervalCounter -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_damageIntervalCounter <= 0 && (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBoss")))
        {
            _damageIntervalCounter = _damageIntervalLength;
            HitEnemy();

            Vector2 enemyDirection = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<EnemyController>().GetDamage(_damage, enemyDirection, _knockbackForce);

            if (_bouncing)
            {
                _movement.Bounce(-enemyDirection);
            }
        }
    }

    public void SetValues(WeaponValues weaponValues)
    {
        transform.localScale = new Vector2(weaponValues.Scale, weaponValues.Scale);

        _damage = weaponValues.Damage;
        _piercing = weaponValues.Piercing;
        _bouncing = weaponValues.Bouncing;
        _knockbackForce = weaponValues.KnockbackForce;
        
        if (weaponValues.Lifetime > 0)
        {
            _lifetimeActive = true;
            _lifetimeCounter = weaponValues.Lifetime;
        }
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
