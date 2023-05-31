using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private bool _active = false;
    private int _level = 0;

    public int Level { get { return _level; } }

    [SerializeField] private int _weaponId = 0;

    private float _attackSpeedCounter;

    [SerializeField] private float _shotSpawnDistance = 20;
    [SerializeField] private float _shotAngleMod = 0;
    [SerializeField] private bool _shotShowToTarget = true;

    WeaponValues[] _weaponValues;

    [SerializeField] private GameObject _shotPrefab;

    private void Start()
    {
        _weaponValues = WeaponLevelValues.GetWeaponValues(_weaponId);
        _attackSpeedCounter = _weaponValues[_level].AttackSpeed;
    }

    private void Update()
    {
        if (_active)
        {
            _attackSpeedCounter -= Time.deltaTime;

            if (_attackSpeedCounter <= 0)
            {
                _attackSpeedCounter += _weaponValues[_level].AttackSpeed;
                FireWeapon();
            }
        }
    }

    public void Upgrade()
    {
        if (_level == 0)
        {
            _level++;
            _active = true;
        }
        else if (_level < _weaponValues.Length - 1)
        {
            _level++;
        }
    }

    private void FireWeapon()
    {
        Vector2 direction = GetNearestEnemyDirection();
        Vector2 spawnPosition = transform.position;
        spawnPosition += direction * _shotSpawnDistance;

        int projectileCountMin = -(_weaponValues[_level].ProjectileCount / 2);
        int projectileCountMax = projectileCountMin + _weaponValues[_level].ProjectileCount;

        for (int i = projectileCountMin; i < projectileCountMax; i++)
        {
            Vector2 moveDirection = Quaternion.AngleAxis(_weaponValues[_level].ProjectileAngleMod * i, Vector3.forward) * direction;
            Quaternion spawnRotation = Quaternion.identity;

            if (_shotShowToTarget)
            {
                float angle = (-Mathf.Atan2(moveDirection.x, moveDirection.y)) * Mathf.Rad2Deg + _shotAngleMod;
                spawnRotation = Quaternion.Euler(0, 0, angle);
            }

            GameObject shot = Instantiate(_shotPrefab, spawnPosition, spawnRotation);
            shot.GetComponent<WeaponShotController>().SetValues(_weaponValues[_level]);
            shot.GetComponent<WeaponShotMovement>().SetValues(_weaponValues[_level], moveDirection, null);
        }
    }

    private Vector2 GetNearestEnemyDirection()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            Vector2 enemyPosition = enemies[0].transform.position;

            foreach (GameObject enemy in enemies)
            {
                float currentDistance = Vector2.Distance(transform.position, enemyPosition);
                float newDistance = Vector2.Distance(transform.position, enemy.transform.position);

                if (newDistance < currentDistance)
                {
                    enemyPosition = enemy.transform.position;
                }
            }

            return (enemyPosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        }

        return GetRandomDirection(); // if no enemy is in range
    }

    private Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    }
}
