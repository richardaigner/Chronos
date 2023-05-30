using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private bool _alive = true;
    private int _health = 5;
    private float _deathTimer = 0.25f;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _xpPrefab;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!_alive)
        {
            UpdateDeathAnimation();
        }
    }

    public void GetDamage(int amount)
    {
        if (_alive)
        {
            _health -= amount;

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
