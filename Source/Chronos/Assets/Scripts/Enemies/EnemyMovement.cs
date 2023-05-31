using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour
{
    private float _speed = 150;

    private float _knockbackTimeCounter = 0;
    private float _knockbackTimeLength = 0.2f;
    private float _knockbackForceCounter = 0;
    private float _knockbackForceMax = 1000;
    private Vector2 _knockbackDirection;

    private Transform _target;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        FindTarget();
        UpdateMovement();
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
            Vector2 knockbackVelocity = Vector2.zero;

            if (_knockbackTimeCounter > 0)
            {
                _knockbackTimeCounter -= Time.deltaTime;
                _knockbackForceCounter = _knockbackForceMax * _knockbackTimeCounter * (1 / _knockbackTimeLength);

                knockbackVelocity = _knockbackDirection * _knockbackForceCounter;
            }

            Vector2 oldPosition = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime) + knockbackVelocity * Time.deltaTime;
            Vector2 newPosition = transform.position;

            Vector2 moveDirection = newPosition - oldPosition;

            _animator.SetFloat("Horizontal", moveDirection.x);
            _animator.SetFloat("Vertical", moveDirection.y);
        }
    }


    public void Knockback(Vector2 fromDirection, float force)
    {
        _knockbackTimeCounter = _knockbackTimeLength;
        _knockbackDirection = fromDirection;
        _knockbackForceMax = force;
    }
}
