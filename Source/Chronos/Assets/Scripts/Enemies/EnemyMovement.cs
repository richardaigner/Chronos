using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour
{
    private float _speed = 200;

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
            Vector2 oldPosition = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            Vector2 newPosition = transform.position;

            Vector2 moveDirection = newPosition - oldPosition;

            _animator.SetFloat("Horizontal", moveDirection.x);
            _animator.SetFloat("Vertical", moveDirection.y);
        }
    }
}
