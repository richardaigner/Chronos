using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private bool _active = false;
    [SerializeField] private int _itemId;
    public int ItemId { get { return _itemId; } }

    private int _level = 0;
    public int Level { get { return _level; } }

    private float _attackSpeedCounter;
    [SerializeField] private float _shotSpawnDistance = 20;
    [SerializeField] private bool _shotSpawnOnTarget = false;
    [SerializeField] private float _shotAngleMod = 0;
    [SerializeField] private bool _shotShowToTarget = true;
    
    WeaponValues[] _weaponValues;

    [SerializeField] private GameObject _shotPrefab;

    private void Start()
    {
        _weaponValues = WeaponLevelValues.GetWeaponValues(_itemId);
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
            Activate();
        }

        _level++;
        
        if (_weaponValues != null && _level == _weaponValues.Length - 1)
        {
            GameObject.Find("UpgradeSelect").GetComponent<UpgradeSelect>().RemovePossibleUpgrade(_itemId);
        }
    }

    public void UpgradeFromEquipment(EquipmentValues equipmentValues)
    {
        for (int i = 0; i < _weaponValues.Length; i++)
        {
            _weaponValues[i].Scale *= equipmentValues.ShotScale;
            _weaponValues[i].AttackSpeed *= equipmentValues.AttackSpeed;
            _weaponValues[i].FlyRange *= equipmentValues.AttackRange;
            _weaponValues[i].Damage = (int)(_weaponValues[i].Damage * equipmentValues.ShotDamage);
            _weaponValues[i].MoveSpeed *= equipmentValues.ShotMoveSpeed;
        }
    }

    public void UpgradeFromDataController(float damage, float attackSpeed)
    {
        for (int i = 0; i < _weaponValues.Length; i++)
        {
            _weaponValues[i].Damage = (int)(_weaponValues[i].Damage * damage);
            _weaponValues[i].AttackSpeed *= attackSpeed;
        }
    }

    private void Activate()
    {
        _active = true;
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

            if (_shotSpawnOnTarget)
            {
                spawnPosition = GetNearestEnemyPosition();
            }

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

    private Vector2 GetNearestEnemyPosition()
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

            return enemyPosition;
        }

        return GetRandomPositionInRange(400); // if no enemy is in range
    }

    private Vector2 GetNearestEnemyDirection()
    {
        return (GetNearestEnemyPosition() - new Vector2(transform.position.x, transform.position.y)).normalized;
    }

    private Vector2 GetRandomPositionInRange(float range)
    {
        return new Vector2(transform.position.x + Random.Range(-range, range), transform.position.y + Random.Range(-range, range));
    }
}
