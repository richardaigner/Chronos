using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed = 400;
    private Vector2 _moveDirection;

    private float _dashCooldownCounter = 0;
    private float _dashCooldownLength = 2;
    private float _dashTimeCounter = 0;
    private float _dashTimeLength = 0.2f;
    private float _dashForceCounter = 0;
    private float _dashForceMax = 2000;
    private Vector2 _dashDirection;

    private float _recoilTimeCounter = 0;
    private float _recoilTimeLength = 0.2f;
    private float _recoilForceCounter = 0;
    private float _recoilForceMax = 1000;
    private Vector2 _recoilDirection;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateCooldowns();
        CheckInput();
        UpdateAnimations();
    }

    private void UpdateCooldowns()
    {
        if (_dashCooldownCounter > 0)
        {
            _dashCooldownCounter -= Time.deltaTime;
        }
    }

    private void CheckInput()
    {
        _moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Mathf.Abs(_moveDirection.x) + Mathf.Abs(_moveDirection.y) > 1f)
        {
            _moveDirection.Normalize();
        }

        if (Input.GetAxisRaw("Dash") == 1)
        {
            if (_dashCooldownCounter <= 0)
            {
                Dash();
            }
        }
    }

    private void UpdateAnimations()
    {
        _animator.SetFloat("Horizontal", _moveDirection.x);
        _animator.SetFloat("Vertical", _moveDirection.y);
        _animator.SetFloat("Speed", _moveDirection.sqrMagnitude);

        if (_moveDirection.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 recoilVelocity = Vector2.zero;
        Vector2 dashVelocity = Vector2.zero;

        if (_recoilTimeCounter > 0)
        {
            _recoilTimeCounter -= Time.deltaTime;
            _recoilForceCounter = _recoilForceMax * _recoilTimeCounter * (1 / _recoilTimeLength);

            recoilVelocity = _recoilDirection * _recoilForceCounter;
        }
        
        if (_dashTimeCounter > 0)
        {
            _dashTimeCounter -= Time.deltaTime;
            _dashForceCounter = _dashForceMax * _dashTimeCounter * (1 / _dashTimeLength);

            dashVelocity = _dashDirection * _dashForceCounter;
        }
        
        _rigidbody.velocity = _moveDirection * _moveSpeed + recoilVelocity + dashVelocity;
    }

    private void Dash()
    {
        _dashCooldownCounter = _dashCooldownLength;
        _dashTimeCounter = _dashTimeLength;
        _dashDirection = _moveDirection;
    }

    public void Recoil(Vector2 fromDirection)
    {
        _recoilTimeCounter = _recoilTimeLength;
        _recoilDirection = fromDirection;
    }
}

