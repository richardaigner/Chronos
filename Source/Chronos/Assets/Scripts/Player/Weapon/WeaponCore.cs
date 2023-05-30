using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCore : MonoBehaviour
{
    private bool _active = true;
 
    private float _attackSpeedCounter;
    [SerializeField] private float _attackSpeedLength = 1;
    
    [SerializeField] private int _shotDamage = 1;
    [SerializeField] private bool _shotPiercing = true;
    [SerializeField] private float _shotSpeed = 2000;
    [SerializeField] private float _shotRange = 500;

    [SerializeField] private int _shotProjectileCount = 1;
    [SerializeField] private int _shotProjectileAngleMod = 0;

    [SerializeField] private float _shotSpawnDistance = 20;
    [SerializeField] private float _shotAngleMod = 0;
    [SerializeField] private bool _shotShowToTarget = true;

    [SerializeField] private GameObject _shotPrefab;

    private void Start()
    {
        _attackSpeedCounter = _attackSpeedLength;
    }

    private void Update()
    {
        if (_active)
        {
            _attackSpeedCounter -= Time.deltaTime;

            if (_attackSpeedCounter <= 0)
            {
                _attackSpeedCounter += _attackSpeedLength;
                FireWeapon();
            }
        }
    }

    private void FireWeapon()
    {
        Vector2 direction = GetNearestEnemyDirection();
        Vector2 spawnPosition = transform.position;
        spawnPosition += direction * _shotSpawnDistance;

        int projectileCountMin = -(_shotProjectileCount / 2);
        int projectileCountMax = projectileCountMin + _shotProjectileCount;

        for (int i = projectileCountMin; i < projectileCountMax; i++)
        {
            Vector2 moveDirection = Quaternion.AngleAxis(_shotProjectileAngleMod * i, Vector3.forward) * direction;
            Quaternion spawnRotation = Quaternion.identity;

            if (_shotShowToTarget)
            {
                float angle = (-Mathf.Atan2(moveDirection.x, moveDirection.y)) * Mathf.Rad2Deg + _shotAngleMod;
                spawnRotation = Quaternion.Euler(0, 0, angle);
            }

            GameObject shot = Instantiate(_shotPrefab, spawnPosition, spawnRotation);
            shot.GetComponent<WeaponShotCore>().SetStats(_shotDamage, _shotPiercing);
            shot.GetComponent<WeaponShotMovement>().SetStats(_shotSpeed, _shotRange, moveDirection, null);
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
