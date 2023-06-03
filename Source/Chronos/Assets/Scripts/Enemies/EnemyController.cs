using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool _alive = true;
    private int _health = 20;
    public int Health { get { return _health; } set { _health = value; } }

    private int _damage = 1;
    private float _deathTimer = 0.25f;

    private SpriteRenderer _spriteRenderer;
    private EnemyMovement _enemyMovement;
    [SerializeField] private GameObject _xpPrefab;
    [SerializeField] private GameObject _deathEffectPrefab;

    [SerializeField] private bool _damageArea = false;
    
    private float _damageAreaCounter = 0;
    [SerializeField] private float _damageAreaLength = 4;
    [SerializeField] private bool _doubleShot = false;
    private bool _doubleShotFired = false;
    [SerializeField] private GameObject _damageAreaPrefab;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (_alive)
        {
            UpdateWeapon();
        }
        else
        {
            UpdateDeathAnimation();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.gameObject.GetComponent<PlayerHealth>().IsInvincible())
        {
            Vector2 playerDirection = (collision.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<PlayerHealth>().GetDamage(_damage, playerDirection);

            Vector2 enemyDirection = (transform.position - collision.transform.position).normalized;
            _enemyMovement.Knockback(enemyDirection, 1000);
        }
    }

    public void GetDamage(int amount, Vector2 direction, float force)
    {
        if (_alive)
        {
            _health -= amount;
            _enemyMovement.Knockback(direction, force);

            if (_health <= 0 && _alive)
            {
                Remove();
            }
        }
    }

    private void Remove()
    {
        _alive = false;

        Instantiate(_xpPrefab, transform.position, Quaternion.identity);
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.AngleAxis(110, new Vector3(1, 0, 0)));

        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void UpdateWeapon()
    {
        if (_damageArea && _alive)
        {
            _damageAreaCounter -= Time.deltaTime;

            if (_doubleShot && !_doubleShotFired && _damageAreaCounter <= 1)
            {
                FireWeapon();
                _doubleShotFired = true;
            }

            if (_damageAreaCounter <= 0)
            {
                _damageAreaCounter += _damageAreaLength;
                FireWeapon();
                _doubleShotFired = false;
            }
        }
    }

    private void FireWeapon()
    {
        Vector2 playerPosition = GameObject.Find("Player").transform.position;
        Vector2 rndPostion = new Vector2(Random.Range(-200, 200), Random.Range(-200, 200));
        Instantiate(_damageAreaPrefab, playerPosition + rndPostion, Quaternion.identity);
    }

    private void UpdateDeathAnimation()
    {
        _deathTimer -= Time.deltaTime;
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, _deathTimer * 4);

        if (_deathTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
