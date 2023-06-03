using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WeaponShotMovement : MonoBehaviour
{
    private float _moveSpeed = 500;
    private float _flyRange = 500;
    private float _rotationSpeed = 0;
    private float _rndFactor = 1;
    private float _circularDistance = 0;
    private Transform _circularOrigin;

    private Vector2 _spawnPosition;
    private Vector2 _direction;
    private Transform _target;

    private Vector2 _playerCenterModifier = new Vector2(0, -10);

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _spawnPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        _moveSpeed = Random.Range(_moveSpeed / _rndFactor, _moveSpeed * _rndFactor);
        _rotationSpeed = Random.Range(_rotationSpeed / _rndFactor, _rotationSpeed * _rndFactor);
        _circularOrigin = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        UpdateMovement();
        UpdateRotation();
        CheckTraveledDistance();
    }

    public void SetValues(WeaponValues weaponValues, Vector2 direction, Transform target)
    {
        _moveSpeed = weaponValues.MoveSpeed;
        _flyRange = weaponValues.FlyRange;
        _rotationSpeed = weaponValues.RotationSpeed;
        _rndFactor = weaponValues.RndFactor;
        _circularDistance = weaponValues.CircularDistance;
        _direction = direction;
        _target = target;
    }

    public void Bounce(Vector2 newDirection)
    {
        _direction = newDirection;
    }

    private void UpdateMovement()
    {
        if (_target != null)
        {
            Vector2 targetPosition = _target.position;
            _direction = (targetPosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        }
        
        if (_circularOrigin != null)
        {
            if (_circularDistance > 0)
            {
                _direction = Quaternion.AngleAxis(_moveSpeed * Time.timeScale, Vector3.forward) * _direction;
                _direction = _direction.normalized;
                Vector2 position = _circularOrigin.position;
                transform.position = position + _direction * _circularDistance + _playerCenterModifier;
            }
            else
            {
                _rigidbody.velocity = _direction * _moveSpeed;
            }
        }
    }

    private void UpdateRotation()
    {
        if (_rotationSpeed > 0)
        {
            transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
        }
    }

    private void CheckTraveledDistance()
    {
        float currentDistance = Vector2.Distance(_spawnPosition, transform.position);

        if (currentDistance >= _flyRange)
        {
            Remove();
        }
    }

    private void Remove()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject);
    }
}
