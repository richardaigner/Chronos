using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemXp : MonoBehaviour
{
    private int _value = 1;
    private bool _moveToPlayer = false;
    private float _moveSpeed = 200;
    private float _moveSpeedIncrease = 1.01f;
    private float _collectRadius = 30;

    private GameObject _playerGameObject;
    [SerializeField] private GameObject _destroyEffectPrefeb;

    private void Start()
    {
        _playerGameObject = GameObject.Find("Player");
    }

    private void Update()
    {
        CheckRangeToPlayer();

        if (_moveToPlayer)
        {
            MoveToPlayer();
        }
    }

    private void CheckRangeToPlayer()
    {
        float distance = Vector2.Distance(_playerGameObject.transform.position, transform.position);

        if (!_moveToPlayer && distance <= _playerGameObject.GetComponent<PlayerStats>().PickUpRange)
        {
            _moveToPlayer = true;
        }

        if (_moveToPlayer && distance <= _collectRadius)
        {
            PlayerCollected();
        }
    }

    private void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, _playerGameObject.transform.position, _moveSpeed * Time.deltaTime);
        _moveSpeed += _moveSpeed * _moveSpeedIncrease * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerCollected();
        }
    }

    private void PlayerCollected()
    {
        RemoveObject();
        _playerGameObject.GetComponent<PlayerLevel>().AddXp(_value);
    }

    private void RemoveObject()
    {
        GetComponent<Collider2D>().enabled = false;
        Instantiate(_destroyEffectPrefeb, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
