using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{
    private int _damage = 2;

    private bool _fadeIn = true;
    private float _timeCounter = 0;
    private float _timeLength = 1;

    private bool _playerEntered;
    private SpriteRenderer _spriteRenderer;

    private float _impactCounter = 0;
    [SerializeField] private GameObject _ImpactEffectPrefab;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_fadeIn)
        {
            if (_timeCounter < _timeLength)
            {
                _timeCounter += Time.deltaTime;
                _spriteRenderer.color = new Color(1, 1, 1, _timeCounter / 1.1f);
            }
            else
            {
                _timeCounter = 0.5f;
                _spriteRenderer.color = new Color(1, 1, 1, 1);
                
                _fadeIn = false;
                Destroy(gameObject, 0.5f);
            }
        }
        else
        {
            _timeCounter -= Time.deltaTime;
            _spriteRenderer.color = new Color(1, 1, 1, _timeCounter * 3);
            CheckCollision();

            _impactCounter -= Time.deltaTime;
            if (_impactCounter <= 0)
            {
                _impactCounter += 0.1f;
                Instantiate(_ImpactEffectPrefab, transform.position + new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0), Quaternion.identity);
            }
        }
    }

    private void CheckCollision()
    {
        if (_playerEntered)
        {
            GameObject player = GameObject.Find("Player");

            if (!player.GetComponent<PlayerHealth>().IsInvincible())
            {
                Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                player.GetComponent<PlayerHealth>().GetDamage(_damage, playerDirection);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerEntered = false;
        }
    }
}
