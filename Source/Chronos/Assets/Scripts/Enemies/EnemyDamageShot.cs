using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDamageShot : MonoBehaviour
{
    private int _damage = 2;

    private float _flyRange = 2000;
    private float _moveSpeed = 500;
    private float _rotationSpeed = 500;

    private Vector2 _spawnPosition;
    private Vector2 _direction;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _spawnPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        _direction = (GameObject.Find("Player").transform.position - new Vector3(transform.position.x, transform.position.y)).normalized;
    }

    private void FixedUpdate()
    {
        UpdateRotation();
        UpdateMovement();
        CheckTraveledDistance();
    }

    private void UpdateMovement()
    {
        _rigidbody.velocity = _direction * _moveSpeed;
    }

    private void UpdateRotation()
    {
        transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
    }

    private void CheckTraveledDistance()
    {
        float currentDistance = Vector2.Distance(_spawnPosition, transform.position);

        if (currentDistance >= _flyRange)
        {
            Remove();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Remove();
            
            GameObject player = collision.gameObject;
            if (!player.GetComponent<PlayerHealth>().IsInvincible())
            {
                Vector2 playerDirection = (player.transform.position - transform.position).normalized;
                player.GetComponent<PlayerHealth>().GetDamage(_damage, playerDirection);
            }
        }
    }

    private void Remove()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject);
    }


}
