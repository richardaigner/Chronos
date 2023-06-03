using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    private float _moveSpeed = 150;
    private Vector2 _moveDirection = Vector2.zero;

    private float _rndMoveSpeed;
    private Vector2 _rndMoveDirection;

    private float _knockbackTimeCounter = 0;
    private float _knockbackTimeLength = 0.3f;
    private float _knockbackForceCounter = 0;
    private float _knockbackForceMax = 1000;
    private Vector2 _knockbackDirection;

    private Transform _target;
    private Animator _animator;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _target = GameObject.Find("Player").transform;

        _rndMoveSpeed = Random.Range(25, 50);
        _rndMoveDirection = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
    }

    private void FixedUpdate()
    {
        //FindTarget();
        UpdateMovement();
        UpdateAnimation();
    }

    private void FindTarget()
    {

        if (_target == null)
        {
            GameObject player = GameObject.Find("Player");
            
            if (player != null )
            {
                _target = player.transform;
            }
        }
    }

    private void UpdateMovement()
    {
        if (_target != null)
        {
            _moveDirection = (_target.position - transform.position).normalized;

            if (_knockbackTimeCounter > 0)
            {
                _knockbackTimeCounter -= Time.deltaTime;
                _knockbackForceCounter = _knockbackForceMax * _knockbackTimeCounter * (1 / _knockbackTimeLength);

                if (_knockbackForceCounter <= 0)
                {
                    _collider.enabled = true;
                }

                _rigidbody.velocity = _knockbackDirection * _knockbackForceCounter;
            }
            else
            {
                _rigidbody.velocity = _moveDirection * _moveSpeed;
            }
        }
        else
        {
            _rigidbody.velocity = _rndMoveDirection * _rndMoveSpeed;
        }
    }

    private void UpdateAnimation()
    {
        if (_target != null)
        {
            _animator.SetFloat("Horizontal", _moveDirection.x);
            _animator.SetFloat("Vertical", _moveDirection.y);
        }
        else
        {
            _animator.SetFloat("Horizontal", _rndMoveDirection.x);
            _animator.SetFloat("Vertical", _rndMoveDirection.y);
        }
    }

    public void Knockback(Vector2 fromDirection, float force)
    {
        _knockbackTimeCounter = _knockbackTimeLength;
        _knockbackDirection = fromDirection;
        _knockbackForceMax = force;
        _collider.enabled = false;
    }
}
