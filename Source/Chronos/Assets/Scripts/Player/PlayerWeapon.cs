using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private bool _active = true;
    private float _attackSpeed = 1.0f; // 0.5 = 2 Attacks per second || lower is faster attack speed
    private float _timeCounter = 1.0f;

    [SerializeField] private GameObject _shotPrefab;

    private void Update()
    {
        if (_active)
        {
            _timeCounter -= Time.deltaTime;

            if (_timeCounter < 0.0f)
            {
                _timeCounter += _attackSpeed;
                FireWeapon();
            }
        }
    }

    private void FireWeapon()
    {
        Instantiate(_shotPrefab, transform.position, Quaternion.identity);
    }

    public void IncreaseAttackSpeed(float amount)
    {
        _attackSpeed -= amount;
    }
}
