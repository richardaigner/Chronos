using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed = 250;
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    private Vector2 _moveDirection;

    private float _dashCooldownCounter = 0;
    private float _dashCooldownLength = 2;
    private float _dashTimeCounter = 0;
    private float _dashTimeLength = 0.3f;
    private float _dashForceCounter = 0;
    private float _dashForce = 1000;
    public float DashForce { get { return _dashForce; } set { _dashForce = value; } }
    private Vector2 _dashDirection;

    private float _knockbackTimeCounter = 0;
    private float _knockbackTimeLength = 0.2f;
    private float _knockbackForceCounter = 0;
    private float _knockbackForce = 1000;
    private Vector2 _knockbackDirection;

    private Collider2D _collider;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private DataController _dataController;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // load upgrade from data controller
        MoveSpeed *= _dataController.GetUpgradeMultiplier("MoveSpeed");
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
        Vector2 knockbackVelocity = Vector2.zero;
        Vector2 dashVelocity = Vector2.zero;

        if (_knockbackTimeCounter > 0)
        {
            _knockbackTimeCounter -= Time.deltaTime;
            _knockbackForceCounter = _knockbackForce * _knockbackTimeCounter * (1 / _knockbackTimeLength);

            knockbackVelocity = _knockbackDirection * _knockbackForceCounter;

            if (_knockbackTimeCounter <= 0)
            {
                gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }
        
        if (_dashTimeCounter > 0)
        {
            _dashTimeCounter -= Time.deltaTime;
            _dashForceCounter = _dashForce * _dashTimeCounter * (1 / _dashTimeLength);

            dashVelocity = _dashDirection * _dashForceCounter;

            if (_dashTimeCounter <= 0)
            {
                gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }
        
        _rigidbody.velocity = _moveDirection * _moveSpeed + knockbackVelocity + dashVelocity;
    }

    private void Dash()
    {
        gameObject.layer = LayerMask.NameToLayer("PlayerKnockback");
        _dashCooldownCounter = _dashCooldownLength;
        _dashTimeCounter = _dashTimeLength;
        _dashDirection = _moveDirection;
    }

    public void Knockback(Vector2 fromDirection)
    {
        gameObject.layer = LayerMask.NameToLayer("PlayerKnockback");
        _knockbackTimeCounter = _knockbackTimeLength;
        _knockbackDirection = fromDirection;
    }
}

