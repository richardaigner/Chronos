using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour
{
    private float _speed = 200;

    private Transform _playerTransform;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _playerTransform = GameObject.Find("Player").transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 oldPosition = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
        Vector2 newPosition = transform.position;

        Vector2 moveDirection = newPosition - oldPosition;

        _animator.SetFloat("Horizontal", moveDirection.x);
        _animator.SetFloat("Vertical", moveDirection.y);
        _animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        if (moveDirection.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
