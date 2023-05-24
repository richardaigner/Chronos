using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private bool _alive = true;
    private int _health = 1;
    private float _deathTimer = 0.5f;

    private Animator _animator;
    [SerializeField] private GameObject _xpPrefab;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void GetDamage(int amount)
    {
        _health -= amount;


        if (_health <= 0 && _alive)
        {
            Remove();
        }
    }

    private void Remove()
    {
        _alive = false;

        _animator.SetBool("Dead", !_alive);
        Instantiate(_xpPrefab, transform.position, Quaternion.identity);

        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, _deathTimer);
    }
}
