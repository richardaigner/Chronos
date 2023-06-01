using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private bool _alive = true;
    private int _health = 40;
    private float _deathTimer = 0.25f;

    private SpriteRenderer _spriteRenderer;
    private EnemyMovement _enemyMovement;
    [SerializeField] private GameObject _xpPrefab;
    [SerializeField] private GameObject _deathEffectPrefab;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (!_alive)
        {
            UpdateDeathAnimation();
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
